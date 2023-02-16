using dir.masterpan_erp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace dir.masterpan_erp.Extensions
{
    public static class IHeaderDictionaryExtensions
    {
        public static CultureInfo GetCultureInfo(this IHeaderDictionary header)
        {
            using (new CultureScope(new CultureInfo("en")))
            {
                var languages = new List<(string, decimal)>();
                string acceptedLanguage = header["Accept-Language"];
                if (acceptedLanguage == null || acceptedLanguage.Length == 0)
                {
                    return new CultureInfo("es-ES");
                }
                string[] acceptedLanguages = acceptedLanguage.Split(',');
                foreach (string accLang in acceptedLanguages)
                {
                    var languageDetails = accLang.Split(';');
                    if (languageDetails.Length == 1)
                    {
                        languages.Add((languageDetails[0], 1));
                    }
                    else
                    {
                        languages.Add((languageDetails[0], Convert.ToDecimal(languageDetails[1].Replace("q=", ""))));
                    }
                }
                string languageToSet = languages.OrderByDescending(a => a.Item2).First().Item1;
                return new CultureInfo(languageToSet);
            }
        }
    }
}
