using System.Threading.Tasks;
using Abp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Shesha;

namespace ShaCompanyName.ShaProjectName.Configuration
{
    public class ShaProjectNameSettingsAppService: SheshaAppServiceBase
    {
        private readonly ISettingManager _settingManager;
        
        public ShaProjectNameSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// Updates ShaProjectName settings
        /// </summary>
        [HttpPost]
        public async Task Update(ShaProjectNameSettingsDto input)
        {
        }        

        /// <summary>
        /// Returns ShaProjectName settings
        /// </summary>
        public async Task<ShaProjectNameSettingsDto> Get()
        {
            var result = new ShaProjectNameSettingsDto()
            {
            };

            return result;
        }

        /// <summary>
        /// Changes setting for tenant with fallback to application
        /// </summary>
        /// <param name="name">Setting name</param>
        /// <param name="value">Setting value</param>
        protected async Task ChangeSettingAsync(string name, string value)
        {
            // todo: move to IShaProjectNameSettings
            if (AbpSession.TenantId.HasValue)
            {
                await _settingManager.ChangeSettingForTenantAsync(AbpSession.TenantId.Value, name, value);
            }
            else
            {
                await _settingManager.ChangeSettingForApplicationAsync(name, value);
            }
        }
    }
}