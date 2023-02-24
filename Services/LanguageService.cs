using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace SvSupportSales.Services
{
    public class LanguageService
    {
        private readonly IStringLocalizer _stringLocalizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(LanguageService);
            //เอาชื่อ SvSupportSales
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _stringLocalizer = factory.Create("SharedResource", assemblyName.Name);
        }
        public string Getkey()
        {
            //LocalizedString mes = _stringLocalizer[key];
            string currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            Debug.WriteLine("--------------"+currentCulture+"-------------");
            return _stringLocalizer["hello"].Value;
        }
    }
}
