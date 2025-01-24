using System;
using System.Threading.Tasks;

namespace NtfuLedenCheck
{
    public class LedenCheck
    {
        //wat variabelen
        private static string NtfuUserName = "YourNtfuUserName";
        private static string NtfuPassWord = "YourNtfuPassWord";
        private static string NtfuUrl = "https://api.ntfu.nl/api/lidcontrole/{0}/{1}/{2}";


        /// <summary>
        /// Doe de NTFU lidcontrole. Het ip adres van de computer / server die de call doet moet bij de ntfu bekend zijn om door de firewall heen te komen met het request
        /// </summary>
        /// <param name="lidnummer">Het 6-cijferige lidnummer om te controleren.</param>
        /// <param name="postcode">De postcode van het lid.</param>
        /// <param name="geboortedatum">De geboortedatum van het lid.</param>
        /// <returns></returns>
        public static async Task<CallNtfuApi.ApiResult> DoLedenCheck(int lidnummer, string postcode, DateTime geboortedatum)
        {
            //controleer of de postcode niet leeg is en tussen 4 en 6 tekens lang, zo niet maak er '0' van
            string pcode = "0";
            if (!string.IsNullOrEmpty(postcode))
            {
                //eventuele spaties verwijderen
                postcode = postcode.Trim().Replace(" ", "");

                if (postcode.Length >= 4 && postcode.Length <= 6)
                {
                    pcode = postcode;
                }
            }

            //controleer of de geboortedatum correct is, zo niet maak er '0' van
            string gbdatum = "0";
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

            //roep de ntfu api aan
            return await CallNtfuApi.CallApi(url, NtfuUserName, NtfuPassWord);
        }
    }
}
