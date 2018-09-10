using System.Reflection;
using Abp.Modules;

namespace WikiTutorial
{
    [DependsOn(typeof(WikiTutorialCoreModule))]
    public class WikiTutorialApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
