using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NtfuLedenCheck
{
    public class CallNtfuApi
    {
        /// <summary>
        /// Roep een (NTFU) api aan en deserialiseer het antwoord.
        /// </summary>
        /// <param name="url">De volledige API url.</param>
        /// <param name="username">De gebruikersnaam voor de API.</param>
        /// <param name="password">Het wachtwoord voor de API.</param>
        /// <returns>CallNtfuApi.ApiResult</returns>
        public static async Task<ApiResult> CallApi(string url, string username, string password)
        {
            //maak een http client
            using (var client = new HttpClient())
            {
                //de logingegevens moeten in de header
                client.DefaultRequestHeaders.Add("username", username);
                client.DefaultRequestHeaders.Add("password", password);

                //een user agent string is noodzakelijk
                client.DefaultRequestHeaders.Add("user-agent", "NTFU LedenCheck");

                //maak de request
                var response = await client.GetAsync(url);

                //het antwoord van de server was ok
                if (response.IsSuccessStatusCode)
                {
                    //haal de antwoord-string uit de response
                    string json = response.Content.ReadAsStringAsync().Result;

                    //deserialize
                    return JsonSerializer.Deserialize<ApiResult>(json);
                }
                else
                {
                    //er ging iets fout
                    return null;
                }
            }
        }


        public class ApiResult
        {
            public bool is_lid { get; set; }
        }
    }
}
