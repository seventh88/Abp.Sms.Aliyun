using System.Threading.Tasks;

namespace Light.Abp.Sms.Aliyun
{
    public interface IAliyunSmsSender
    {
        Task<SendSmsResponse> SendAsync(SendSmsRequest req);
    }
}