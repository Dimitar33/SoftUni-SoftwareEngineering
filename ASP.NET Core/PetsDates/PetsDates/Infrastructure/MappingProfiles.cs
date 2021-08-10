using AutoMapper;
using PetsDates.Data.Models;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets;

namespace PetsDates.Infrastructure
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PetsDetailsServiceModel, AddPetViewModel>();
            CreateMap<Pet, PetsDetailsServiceModel>()
                .ForMember(x => x.Breed , cfg => cfg.MapFrom(x => x.Breed.Name))
                .ForMember(x => x.FirstName, c => c.MapFrom(x => x.Owner.FirtsName));
        }
    }
}
