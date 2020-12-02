using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Light.Abp.Sms.Aliyun
{
    public class AbpSmsAliyunModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<AbpSmsAliyunOption>(options =>
            {
                options.RegionId = configuration["Ali:RegionId"];
                options.AccessKey = configuration["Ali:AccessKey"];
                options.AccessKeySecret = configuration["Ali:AccessKeySecret"];
            });
        }
    }
}
