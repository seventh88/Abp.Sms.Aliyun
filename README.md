# Abp.Sms.Aliyun

ABP 阿里云短信模块

## 1. 介绍

**Light.Abp.Sms.Aliyun** 库实现了发送阿里云短信。

## 2. 如何使用?

### 2.1 安装

开发人员可以通过 NuGet 搜索 `Light.Abp.Sms.Aliyun` 安装组件

### 2.2 配置
配置示例:

```csharp
    [DependsOn(typeof(AbpSmsAliyunModule))]
    public class TestModule : AbpModule
    {
            public override void ConfigureServices(ServiceConfigurationContext context)
            {
                Configure<AbpSmsAliyunOption>(op =>
                {
                    op.RegionId="";
                    // 阿里云 API 的访问 Id。
                    op.AccessKey = "Key";
                    // 阿里云 API 的访问密钥。
                    op.AccessKeySecret = "Secret";
                });
            }
    }
```


### 2.3 调用示例
在AppService中，注入IAliyunSmsSender即可使用
```csharp
    public class TestAppService : ApplicationService
    {
        private readonly IdentityUserManager _userManager;
        private readonly IAliyunSmsSender _aliyunSmsSender;

        public CaptchaAppService(IdentityUserManager userManager,
            IAliyunSmsSender aliyunSmsSender)
        {
            _userManager = userManager;
            _aliyunSmsSender = aliyunSmsSender;
        }
       
        var smsRequest = new SendSmsRequest()
        {
            PhoneNumbers = "",
            TemplateCode = "",
            TemplateParam = JsonConvert.SerializeObject(new { code }),
            SignName =  "",
        };
        
    }
```
