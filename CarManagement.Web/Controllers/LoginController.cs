using Azure.Core;
using CarManagement.Core.ViewModels.LoginToken;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarManagement.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            try
            {
                var apiUrl = _configuration["ApiEndPoints:LoginUrl"]; 
                var clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                var client = new HttpClient(clientHandler);
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = JsonConvert.SerializeObject(loginViewModel); 
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("", content);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<APIResponseVM<TokenResponseVM>>(responseContent);

                if (response.IsSuccessStatusCode)
                {
					HttpContext.Session.SetString("AccessToken",result.Data.AccessToken);
					TempData["Success"] = result.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result.Message;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred during login.";
                return View();
            }
        }


    }
}
