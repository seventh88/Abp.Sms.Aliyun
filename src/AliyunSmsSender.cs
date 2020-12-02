using System.Text.Json;
using System.Threading.Tasks;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;

namespace Light.Abp.Sms.Aliyun
{
    public class AliyunSmsSender : IAliyunSmsSender, ISingletonDependency
    {
        private readonly ILogger<AliyunSmsSender> _logger;
        private readonly DefaultAcsClient client;

        public AliyunSmsSender(IOptions<AbpSmsAliyunOption> options, ILogger<AliyunSmsSender> logger)
        {
            _logger = logger;
            var config = options.Value;
            IClientProfile profile = DefaultProfile.GetProfile(config.RegionId, config.AccessKey, config.AccessKeySecret);
            client = new DefaultAcsClient(profile);
        }


        public virtual async Task<SendSmsResponse> SendAsync(SendSmsRequest req)
        {
            CommonRequest request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "SendSms"
            };
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("PhoneNumbers", req.PhoneNumbers);
            request.AddQueryParameters("SignName", req.SignName);
            request.AddQueryParameters("TemplateCode", req.TemplateCode);
            request.AddQueryParameters("TemplateParam", req.TemplateParam);

            var commonRes = client.GetCommonResponse(request);
            _logger.LogInformation("Send Aliyun Sms：req:{@req} res:{@commonRes}", req, commonRes);
            var result = JsonSerializer.Deserialize<SendSmsResponse>(commonRes.Data);
            return await Task.FromResult(result);
        }
    }
}
