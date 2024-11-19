namespace WorkFlex.Payment.Configs.ZaloPay.Config
{
    public class ZaloPayConfig
    {
        public static string ConfigName => "ZaloPay";

        public int AppId { get; set; }

        public string AppUser { get; set; } = string.Empty;

        public string RedirectUrl { get; set; } = string.Empty;

        public string PaymentUrl { get; set; } = string.Empty;

        public string RedirectWebUrl { get; set; } = string.Empty;

        public string IpnUrl { get; set; } = string.Empty;

        public string Key1 { get; set; } = string.Empty;

        public string Key2 { get; set; } = string.Empty;
    }
}
