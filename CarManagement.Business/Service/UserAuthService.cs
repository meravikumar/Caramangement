using CarManagement.Business.IServices;
using CarManagement.Core.Constants;
using CarManagement.Core.ViewModels.LoginToken;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace CarManagement.Business.Service
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public UserAuthService(IConfiguration configuration,IDataProtectionProvider dataProtectionProvider)
        {
            _configuration = configuration;
            _dataProtectionProvider = dataProtectionProvider;
        }
        public APIResponseVM<TokenResponseVM> Login(LoginViewModel loginViewModel)
        {
            var apiResponse = new APIResponseVM<TokenResponseVM>();
            string username = _configuration["Authentication:Username"];
            string password = _configuration["Authentication:Password"];
            
           
            if (loginViewModel.Email == username && loginViewModel.Password == password)
            {
                var accessToken = GenerateJWTToken(username);
                var tokenResponseVM = new TokenResponseVM();
                tokenResponseVM.AccessToken = accessToken;
                apiResponse.Message = StringConstants.LoginSuccess;
                apiResponse.StatusCode = (int)HttpStatusCode.OK;
                apiResponse.Data = tokenResponseVM;
                return apiResponse;
            }
            apiResponse.Message = StringConstants.LoginFailed;
            apiResponse.StatusCode = (int)HttpStatusCode.BadRequest;
            apiResponse.Data = null;
            return apiResponse;
        }
        private string GenerateJWTToken(string username)
        {
            var authClaims = new List<Claim>
            {
                new Claim("Username", username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(90),
                claims: authClaims,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
