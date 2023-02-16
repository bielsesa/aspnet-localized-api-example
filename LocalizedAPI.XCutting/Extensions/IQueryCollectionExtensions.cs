using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace dir.masterpan_erp.Extensions
{
    public static class IQueryCollectionExtensions
    {
        public static CultureInfo GetCultureInfo(this IQueryCollection query)
        {
            // TODO: Get CultureName from Query (BusinessCultureName and/or UserCultureName)
            return new CultureInfo("es");
        }
    }
}
