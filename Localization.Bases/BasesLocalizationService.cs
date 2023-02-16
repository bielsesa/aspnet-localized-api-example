using Microsoft.Extensions.Localization;

namespace dir.masterpan_erp.Bases
{
    public class BasesLocalizationService : IStringLocalizer<BasesLocalizationService>
    {
        private readonly IStringLocalizer<BasesLocalizationService> _localizer;

        public BasesLocalizationService(IStringLocalizer<BasesLocalizationService> localizer)
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
