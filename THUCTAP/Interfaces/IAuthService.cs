using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IAuthService
    {
        string? Authenticate(LoginRequest request);
    }
}