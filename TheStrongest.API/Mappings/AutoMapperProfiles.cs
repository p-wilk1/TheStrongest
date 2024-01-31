using AutoMapper;
using TheStrongest.API.Models.Domain;
using TheStrongest.API.Models.DTO;

namespace TheStrongest.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Training, TrainingDto>().ReverseMap();
            CreateMap<PerformedExercise, PerformedExerciseDto>().ReverseMap();
            CreateMap<Set, SetDto>().ReverseMap();
            CreateMap<CreateTrainingRequestDto, TrainingDto>().ReverseMap();
            CreateMap<CreateTrainingRequestDto, Training>().ReverseMap();
            CreateMap<ExerciseInfo, ExerciseInfoDto>().ReverseMap();
            CreateMap<SecondaryMuscles, SecondaryMusclesDto>().ReverseMap();
            CreateMap<Instructions, InstructionsDto>().ReverseMap();
            CreateMap<ExerciseInfo, ExerciseInfoGetAllDto>().ReverseMap();
            CreateMap<SecondaryMuscles, SecondaryMusclesGetDto>().ReverseMap();
            CreateMap<GetOwnTrainingDto, Training>().ReverseMap();
            CreateMap<UpdateTrainingRequestDto, Training>().ReverseMap();
        }
    }
}