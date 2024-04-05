using System.Net.Http.Headers;
using SpotifyAPI.Models;
using Newtonsoft.Json;

namespace SpotifyAPI
{
    public class SpotifyApiAppService
    {
        static HttpClient client = new HttpClient();
        static HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://spotify23.p.rapidapi.com/concerts/?gl=Washington"),
            Headers = {
                    { "X-RapidAPI-Key", "bb2c2200e7mshb600781897d2068p1ad85ajsn4b198a19e1a2" },
                    { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
                },
        };
        public SpotifyApiAppService()
        {

        }

        public static async Task<List<ConcertsResultsDto>> GetAllConcerts()
        {
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ///event title, event date, venue, number of artists and concerts
                body = body.ToString();
                
                Console.WriteLine(body);
                List<ConcertsResultsDto> concertsResultsDto = new List<ConcertsResultsDto>();
                var model = JsonConvert.DeserializeObject<ReponseResult>(body);
                var result = model.events.Where(c => c.location == "Washington" && c.openingDate == c.closingDate).ToList();

                foreach(var resultDto in result)
                {
                    string Title = "";
                    string Date = "";
                    string venue = "";
                    foreach (var item in resultDto.concerts)
                    {
                        Title = item.concert.title;
                        Date = item.concert.date;
                        venue = item.concert.venue;
                    }
                    
                    int artistsCount = resultDto.artists.Count();
                    int concertsCount = resultDto.concerts.Count();
                    ConcertsResultsDto concertsResults = new ConcertsResultsDto();
                    concertsResults.title = Title;
                    concertsResults.date = Date;
                    concertsResults.venue = venue;
                    concertsResults.artistsCount = artistsCount;
                    concertsResults.concertsCount = concertsCount;
                    concertsResultsDto.Add(concertsResults);
                }

                concertsResultsDto.OrderByDescending(x => x.venue).ThenByDescending(x => x.date).ToList();



                return concertsResultsDto;
            }
        }
    }
}
