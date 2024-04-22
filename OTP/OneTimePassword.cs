using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace otp1
{
    public class OneTimePassword
    {

        public int Id { get; set; }
        public string Cod { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
