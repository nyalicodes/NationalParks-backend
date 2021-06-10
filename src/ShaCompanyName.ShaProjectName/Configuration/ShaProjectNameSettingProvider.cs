using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace ShaCompanyName.ShaProjectName.Configuration
{
    /// <summary>
    /// Defines ShaProjectName settings
    /// </summary>
    public class ShaProjectNameSettingProvider : SettingProvider
    {
        protected string LocalizationSourceName { get; set; }

        public ShaProjectNameSettingProvider()
        {
            LocalizationSourceName = "ShaProjectName";
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
            {
                //new SettingDefinition(ShaProjectNameSettingNames.RevisitPeriod, (7*24*60).ToString() /* 7 days */, L("DSD_NPO_RevisitPeriod"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}
