namespace API.Helpers
{
    public class RatingParams: PaginationParams
    {
        public string Username { get; set; }
        public string Container { get; set; }
    }
}