using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using WikiTutorial.ClientServices.Dtos;
using WikiTutorial.Entities.ClientEntity;
using WikiTutorial.Entities.ProductEntity;
using WikiTutorial.ProductServices.Dtos;

namespace WikiTutorial
{
    [DependsOn(typeof(WikiTutorialCoreModule), typeof(AbpAutoMapperModule))]
    public class WikiTutorialApplicationModule : AbpModule
    {
        // ----- inserir daqui -----
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<CreateProductInput, Product>()
                .ConstructUsing(x => new Product(x.Name, x.Description, x.Value));

                config.CreateMap<UpdateProductInput, Product>()
                .ConstructUsing(x => new Product(x.Name, x.Description, x.Value));

                config.CreateMap<CreateClientInput, Client>()
               .ConstructUsing(x => new Client(x.Name, x.LastName, x.Cpf));

                config.CreateMap<UpdateClientInput, Client>()
                .ConstructUsing(x => new Client(x.Name, x.LastName, x.Cpf));
            });
        }

        public override void Initialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration => {
                configuration.CreateMissingTypeMaps = true;
            });
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
