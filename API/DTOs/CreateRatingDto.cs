namespace API.DTOs
{
    public class CreateRatingDto
    {
        public string RecipientUsername { get; set; }
        public string Content { get; set; }
        public int Score {get; set;}
        public int ScoreAvg {get; set;}
    }
}