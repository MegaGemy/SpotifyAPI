namespace SpotifyAPI.Models
{
    public class ConcertsResultsDto
    {
        public string title { get; set; }
        public string date { get; set; }
        public string venue { get; set; }
        public int artistsCount { get; set; }
        public int concertsCount { get; set; }
    }
}
