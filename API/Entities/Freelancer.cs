namespace API.Entities
{
    public class Freelancer: AppUser
    {
        public string Biography { get; set; }
        public string Skills { get; set; }
        public string Profession { get; set; }
        public string WorkHistory { get; set; }       
    }
}