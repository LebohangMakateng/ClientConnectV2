using System;

namespace API.DTOs
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderUsername { get; set; }
        public string SenderPhotoUrl { get; set; }
        public int RecipientId { get; set; }
        public string RecipientUsername { get; set; }
        public string RecipientPhotoUrl { get; set; }
        public string Content { get; set; }
        public int Score {get; set;}
        public int ScoreAvg {get; set;}
        public DateTime? DateRead { get; set; }
        public DateTime RateSent { get; set; }
    }
}