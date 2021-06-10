using System.Reflection;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using ShaCompanyName.ShaProjectName.Authorization;
using ShaCompanyName.ShaProjectName.Configuration;
using ShaCompanyName.ShaProjectName.Localization;
using Shesha;
using Shesha.Authorization;

namespace ShaCompanyName.ShaProjectName
{
    /// <summary>
    /// ShaProjectName Module
    /// </summary>
    [DependsOn(
        typeof(SheshaCoreModule)
    )]
    public class ShaProjectNameModule : AbpModule
    {
        /// inheritedDoc
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            IocManager.IocContainer.Register(
              Component.For<ICustomPermissionChecker>().Forward<IShaProjectNamePermissionChecker>().Forward<ShaProjectNamePermissionChecker>().ImplementedBy<ShaProjectNamePermissionChecker>().LifestyleTransient()
          );

            var thisAssembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }

        /// inheritedDoc
        public override void PreInitialize()
        {
            base.PreInitialize();

            Configuration.Settings.Providers.Add<ShaProjectNameSettingProvider>();
            Configuration.Authorization.Providers.Add<ShaProjectNameAuthorizationProvider>();

            ShaProjectNameLocalizationConfigurer.Configure(Configuration.Localization);
        }

        /// inheritedDoc
        public override void PostInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(ShaProjectNameModule).Assembly,
                moduleName: "ShaProjectName",
                useConventionalHttpVerbs: true);
        }
    }
}