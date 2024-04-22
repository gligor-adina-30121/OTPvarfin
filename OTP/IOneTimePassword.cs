namespace otp1
{
    public interface IOneTimePasswordService
    {
        string GenerateOTP();
        bool ValidateOTP(string otp);
    }
}
