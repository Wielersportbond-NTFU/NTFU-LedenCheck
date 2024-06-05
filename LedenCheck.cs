using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NtfuLedenCheck
{
    public class LedenCheck
    {
        //wat variabelen
        private static string NtfuUserName = "YourNtfuUserName";
        private static string NtfuPassWord = "YourNtfuPassWord";
        private static string NtfuUrl = "https://api.ntfu.nl/api/lidcontrole/{0}/{1}/{2}";


        //doe de call naar de ntfu api
        //het ip adres van de computer / server die de call doet moet bij de ntfu bekend zijn om door de firewall heen te komen met het request
        public static async Task<ControleResultaat> DoLedenCheck(int lidnummer, string postcode, DateTime geboortedatum)
        {
            //controleer of de postcode niet leeg is en tussen 4 en 6 tekens lang, zo niet maak er 'na' of '0' van
            string pcode = "na";
            if (!string.IsNullOrEmpty(postcode))
            {
                //eventuele spaties verwijderen
                postcode = postcode.Trim().Replace(" ", "");

                if (postcode.Length >= 4 && postcode.Length <= 6)
                {
                    pcode = postcode;
                }
            }

            //controleer of de geboortedatum correct is, zo niet maak er 'na' of '0' van
            string gbdatum = "na";
            if (geboortedatum.Year > 1900 && geboortedatum.Year <= DateTime.Now.Year)
            {
                gbdatum = geboortedatum.ToString("dd-MM-yyyy");
            }

            //als het lidnummer buiten de range valt of zowel geboortedatum als postcode zijn niet goed dan geen call doen
            if (lidnummer < 200000 || lidnummer > 1000000 || (gbdatum == "na" && pcode == "na"))
            {
                return null;
            }

            //bouw de correcte url
            string url = string.Format(NtfuUrl, lidnummer, pcode, gbdatum);

            //maak een http client
            using (var client = new HttpClient())
            {
                //de logingegevens moeten in de header
                client.DefaultRequestHeaders.Add("username", NtfuUserName);
                client.DefaultRequestHeaders.Add("password", NtfuPassWord);

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
                    return JsonSerializer.Deserialize<ControleResultaat>(json);
                }
                else
                {
                    //er ging iets fout
                    return null;
                }
            }
        }


        public class ControleResultaat
        {
            public bool is_lid { get; set; }
        }
    }
}
