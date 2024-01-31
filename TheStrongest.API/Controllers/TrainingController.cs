using Microsoft.AspNetCore.Mvc;
using TheStrongest.API.Models.Domain;
using TheStrongest.API.Models.DTO;
using TheStrongest.API.Repositories.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace TheStrongest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository trainingRepository;
        private readonly IMapper mapper;
        private readonly UserManager<OwnUser> userManager;

        public TrainingController(ITrainingRepository trainingRepository, IMapper mapper, UserManager<OwnUser> userManager)
        {
            this.trainingRepository = trainingRepository;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await trainingRepository.GetById(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOwnTrainings()
        {
            var authorId = userManager.GetUserId(User);

            var exisitingTrainings = await trainingRepository.GetOwnTrainingsAsync(authorId);
            var response = new List<GetOwnTrainingDto>();

            foreach (var ex in exisitingTrainings)
            {
                var ownTraining = mapper.Map<GetOwnTrainingDto>(ex);
                response.Add(ownTraining);
            }

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPublic()
        {
            var trainings = await trainingRepository.GetAllPublicAsync();
            var response = new List<TrainingDto>();
            foreach (var training in trainings)
            {
                var ex = mapper.Map<TrainingDto>(training);
                response.Add(ex);
            }

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTraining(CreateTrainingRequestDto request)
        {
            var training = mapper.Map<Training>(request);

            var userid = userManager.GetUserId(User);

            await trainingRepository.CreateAsync(training, userid);

            var response = mapper.Map<TrainingDto>(training);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTraining([FromRoute] Guid id)
        {
            var existingTraining = await trainingRepository.Delete(id);
            if (existingTraining != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTraining([FromRoute] Guid id, UpdateTrainingRequestDto request)
        {
            var check = await trainingRepository.GetById(id);
            if (check.AuthorId != userManager.GetUserId(User))
            {
                return Unauthorized();
            }
            var training = mapper.Map<Training>(request);
            training.Id = id;
            training.AuthorId = userManager.GetUserId(User);
            var exisitingExercise = await trainingRepository.UpdateAsync(training);
            if (exisitingExercise != null)
            {
                var response = mapper.Map<TrainingDto>(training);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}