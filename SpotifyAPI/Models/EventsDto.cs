namespace SpotifyAPI.Models
{
    public class EventsDto
    {
        public List<string> artists { set; get; }
        public string venue { set; get; }
        public string location { set; get; }
        public string openingDate { set; get; }
        public string closingDate { set; get; }

        public List<concertsDto> concerts { set; get; }
        public string source { set; get; }
    }
}
