namespace ApiStructure.Services
{
    public class LanguageService : ILanguageService
    {
        private string _lang;

        public string GetLanguage()
        {
            return _lang;
        }

        public void SetLanguage(string lang)
        {
            _lang = lang;
        }
    }
}
