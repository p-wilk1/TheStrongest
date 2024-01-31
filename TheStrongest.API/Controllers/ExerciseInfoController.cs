using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TheStrongest.API.Data;
using TheStrongest.API.Models.Domain;
using TheStrongest.API.Models.DTO;
using TheStrongest.API.Repositories.Interface;

namespace TheStrongest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExerciseInfoController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IExerciseInfoRepository exerciseInfoRepository;
        private readonly ApplicationDbContext dbContext;

        public ExerciseInfoController(IMapper mapper, IExerciseInfoRepository exerciseInfoRepository, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.exerciseInfoRepository = exerciseInfoRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetFromLocalDb()
        {
            var result = await exerciseInfoRepository.GetAll();
            var response = new List<ExerciseInfoGetAllDto>();
            foreach (var exercise in result)
            {
                var existingInfo = new ExerciseInfoGetAllDto
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    BodyPart = exercise.BodyPart,
                    Equipment = exercise.Equipment,
                    GifUrl = exercise.GifUrl,
                    Target = exercise.Target,
                    Instructions = new List<InstructionsDto>(),
                    SecondaryMuscles = new List<SecondaryMusclesGetDto>()
                };
                foreach (var instruction in exercise.Instructions)
                {
                    var ins = new InstructionsDto { Description = instruction.Description };
                    existingInfo.Instructions.Add(ins);
                }
                foreach (var secMuscle in exercise.SecondaryMuscles)
                {
                    var secMuscles = new SecondaryMusclesGetDto { Name = secMuscle.Name };
                    existingInfo.SecondaryMuscles.Add(secMuscles);
                }
                response.Add(existingInfo);
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFromLocalDb([FromRoute] string id)
        {
            var exerciseInfo = await exerciseInfoRepository.GetById(id);
            if (exerciseInfo == null)
                return BadRequest();

            var response = mapper.Map<ExerciseInfoGetAllDto>(exerciseInfo);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetFromApi()
        {
            List<Instructions> instructs = dbContext.Instructions.ToList();
            dbContext.Instructions.RemoveRange(instructs);
            List<SecondaryMuscles> secmusc = dbContext.SecondaryMuscles.ToList();
            dbContext.SecondaryMuscles.RemoveRange(secmusc);
            List<ExerciseInfo> infs = dbContext.ExerciseInfos.ToList();
            dbContext.ExerciseInfos.RemoveRange(infs);
            dbContext.SaveChanges();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://exercisedb.p.rapidapi.com/exercises?limit=1400"),
                Headers =
                 {
                { "X-RapidAPI-Key", "4bfed9dbdcmshd37db87fb72ea5dp11b268jsn35f388b533ae" },
                { "X-RapidAPI-Host", "exercisedb.p.rapidapi.com" },
                 },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var exercises = JsonConvert.DeserializeObject<List<ExerciseInfoDto>>(body);

                if (exercises != null && exercises.Count > 0)
                {
                    foreach (var exercise in exercises)
                    {
                        var info = new ExerciseInfo
                        {
                            Id = exercise.Id,
                            BodyPart = exercise.BodyPart,
                            Equipment = exercise.Equipment,
                            GifUrl = exercise.GifUrl,
                            Name = exercise.Name,
                            Target = exercise.Target,
                            Instructions = new List<Instructions>(),
                            SecondaryMuscles = new List<SecondaryMuscles>(),
                        };

                        foreach (var instruction in exercise.Instructions)
                        {
                            var d = new InstructionsDto { Description = instruction };
                            var q = mapper.Map<Instructions>(d);
                            info.Instructions.Add(q);
                        }

                        foreach (var secondaryMuscle in exercise.SecondaryMuscles)
                        {
                            var req = await dbContext.SecondaryMuscles.FirstOrDefaultAsync(x => x.Name == secondaryMuscle);
                            if (req != null)
                            {
                                info.SecondaryMuscles.Add(req);
                            }
                            else
                            {
                                var d = new SecondaryMusclesDto { Name = secondaryMuscle };
                                var q = mapper.Map<SecondaryMuscles>(d);
                                info.SecondaryMuscles.Add(q);
                            }
                        }

                        await dbContext.ExerciseInfos.AddAsync(info);
                        await dbContext.SaveChangesAsync();
                    }

                    return Ok(exercises);
                }
                return BadRequest();
            }
        }
    }
}