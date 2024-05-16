using CarManagement.Core.ViewModels.Companies;
using CarManagement.Core.ViewModels.LoginToken;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarManagement.Web.Controllers
{
	public class CompanyController : Controller
	{
		private readonly string apiUrl = "http://localhost:7291/api/Company/";
		private readonly HttpClient client;
		private readonly string newApi = "http://localhost:7291/api/Company/AddCompany";

		public CompanyController()
		{
			var handler = new HttpClientHandler();
			// Bypass SSL certificate validation (not recommended for production)
			handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
			client = new HttpClient(handler);
			// Ensure we accept JSON responses
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		[HttpGet]
		public IActionResult Index()
		{
			List<CreateCompanyVM> companies = new List<CreateCompanyVM>();
			try
			{
				HttpResponseMessage response = client.GetAsync(apiUrl).Result;
				if (response.IsSuccessStatusCode)
				{
					string result = response.Content.ReadAsStringAsync().Result;
					companies = JsonConvert.DeserializeObject<List<CreateCompanyVM>>(result);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			return View(companies);
		}
		[HttpPost]
		public async Task<ActionResult> AddCompany(CreateCompanyVM createCompanyVM)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var response = await $"{apiUrl}AddCompany".PostJsonAsync(createCompanyVM).ReceiveJson<CreateCompanyVM>();

					return Json(response);
				}
				else
				{
					var errorMessage = "Invalid model state. Please check your input.";
					return Json(new { success = false, message = errorMessage });
				}
			}
			catch (Exception ex)
			{
				var errorMessage = "An error occurred while processing your request: " + ex.Message;
				return Json(new { success = false, message = errorMessage });
			}
		}

		

		[HttpPut]
		public async Task<ActionResult> EditCompany(int id, CreateCompanyVM createCompanyVM)
		{
			try
			{
				var Response = await  $"{apiUrl}UpdateCompany/{id}".PutJsonAsync(createCompanyVM).ReceiveJson<CreateCompanyVM>();
				return Json(Response);
			}
			catch (FlurlHttpException ex)
			{
				var errorMessage = "An error occurred while processing your request: " + ex.Message;
				return Json(new { success = false, message = errorMessage });
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetCompany(int id)
		{
			try
			{
				var response = await $"{apiUrl}GetCompany?companyId={id}".GetJsonAsync<object>();
				return Json(response);
			}
			catch (FlurlHttpException ex)
			{
				var errorMessage = "An error occurred while processing your request: " + ex.Message;
				return Json(new { success = false, message = errorMessage });
			}
		}


		[HttpDelete]
		public async Task<ActionResult> DeleteCompany(int id)
		{
			try
			{
				var response = await $"{apiUrl}DeleteCompany/{id}".DeleteAsync().ReceiveJson<APIResponseVM<object>>();
				return Json(Response);
			}
			catch (FlurlHttpException ex)
			{
				var errorMessage = "An error occurred while processing your request: " + ex.Message;
				return Json(new { success = false, message = errorMessage });
			}
		}


		/*protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				client.Dispose();
			}
			base.Dispose(disposing);
		}*/
	}
}
