using Microsoft.Extensions.Localization;

namespace dir.masterpan_erp.Comunes
{
    public class ComunesLocalizationService : IStringLocalizer<ComunesLocalizationService>
    {
        private readonly IStringLocalizer<ComunesLocalizationService> _localizer;

        public ComunesLocalizationService(IStringLocalizer<ComunesLocalizationService> localizer)
        {
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
        }

        public LocalizedString this[string name] => _localizer[name];

        public LocalizedString this[string name, params object[] arguments] => _localizer[name, arguments];

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _localizer.GetAllStrings(includeParentCultures);
        }
    }
}
