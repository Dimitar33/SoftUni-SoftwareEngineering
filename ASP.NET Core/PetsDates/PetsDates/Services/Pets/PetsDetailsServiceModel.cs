namespace PetsDates.Services.Pets
{
    public class PetsDetailsServiceModel : PetsListingServiceModel
    {
        public int BreedId { get; set; }
        public string OwnerId { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}
