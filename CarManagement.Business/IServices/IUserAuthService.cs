using CarManagement.Core.ViewModels.LoginToken;

namespace CarManagement.Business.IServices
{
    public interface IUserAuthService
    {
        APIResponseVM<TokenResponseVM> Login(LoginViewModel loginViewModel);
    }

}
