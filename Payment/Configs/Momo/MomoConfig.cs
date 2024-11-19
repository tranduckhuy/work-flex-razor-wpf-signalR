namespace WorkFlex.Payment.Configs.Momo
{
    public class MomoConfig
    {
        public static string ConfigName => "Momo";
        public string PartnerCode { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = string.Empty;
        public string RedirectWebUrl { get; set; } = string.Empty;
        public string IpnUrl { get; set; } = string.Empty;
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public string PaymentUrl { get; set; } = string.Empty;
    }
}
