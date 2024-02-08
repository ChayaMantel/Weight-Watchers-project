using AutoMapper;
using Subscriber.CORE.Interface_DAL;
using Subscriber.CORE.Interface_Service;

using Subscriber.Services;
using Subscriber.DAL;

namespace Subscriber.WebWpi.Config
{
    public static  class ConfigureServices
    {

        public static void ConfigurationService(this IServiceCollection services)
        {

            services.AddScoped<IWeightWatchersService, WeightWatchersService>();
            services.AddScoped<IWeightWatchersRepository, WeightWatchersRepository>();
            

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeightWatchersProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
