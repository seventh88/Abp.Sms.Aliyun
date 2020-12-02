namespace Light.Abp.Sms.Aliyun
{
    public class AbpSmsAliyunOption
    {
        public string RegionId { get; set; }

        /// <summary>
        /// AccessKey ID
        /// </summary>
        /// <value>The access key.</value>
        public string AccessKey { get; set; }

        /// <summary>
        /// 秘钥参数
        /// </summary>
        public string AccessKeySecret { get; set; }

    }
}
