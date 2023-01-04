using Microsoft.AspNetCore.Mvc;
using MulakatProjesi.Models;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;



namespace MulakatProjesi.Controllers;

public class HomeController : Controller
{
	private readonly IConfiguration _configuration;

	private readonly string _token;

	public HomeController(IConfiguration configuration)
	{
		_configuration = configuration;
		_token = configuration.GetValue<string>("Token");
	}

	[HttpGet]
	public IActionResult Index()
	{

		return View();
	}

	// ###########################################################

	/// <summary>
	/// İletişim sayfasına gider
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public IActionResult Contact()
	{
		return View();
	}

	/// <summary>
	/// İletişim formu post metodu
	/// </summary>
	/// <param name="model"></param>
	/// <returns></returns>
	[HttpPost]
	public IActionResult Contact(ContactVM model)
	{

		if (!ModelState.IsValid) return BadRequest();
		try
		{
			using var httpClient = new HttpClient();

			httpClient.DefaultRequestHeaders.Add("Authorization", _token);

			
			var serializeform = JsonConvert.SerializeObject(model);

			StringContent stringContent = new StringContent(serializeform, Encoding.UTF8, "application/json");

			var result = httpClient.PostAsync("https://api.kitapbulal.com/chat/add", stringContent).Result;

			string mesaj = string.Empty;
			if (result.IsSuccessStatusCode)
			{

				mesaj = "Mesaj Gönderilmiştir";


			}
			else
			{
				mesaj = "Mesaj Gönderilemedi !";

			}

			ViewBag.Success = mesaj;
		}
		catch (Exception)
		{		

			ViewBag.Success = "Mesaj Gönderilemedi !"; 

		}




		return View();
	}

	// ###########################################################

	/// <summary>
	/// Ürünler sayfasına gider
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	public IActionResult Products()
	{

		List<ProductsVM> products = new List<ProductsVM>();
		try
		{
			using (HttpClientHandler handler = new HttpClientHandler())
			{
				handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

				using (HttpClient hc = new HttpClient(handler))
				{

					string strUrl = "https://api.kitapbulal.com/test/getproducts";


					using (var rslt = hc.GetAsync(strUrl))
					{
						if (rslt != null && rslt.Result != null && rslt.Result.StatusCode == System.Net.HttpStatusCode.OK)
						{
							var result = rslt.Result.Content.ReadAsStringAsync();
							result.Wait();

							products = JsonConvert.DeserializeObject<List<ProductsVM>>(result.Result);
						}
					}


				}
			}

			return View(products);
		}
		catch (Exception)
		{

			return View(products);
		}

	}

	[HttpGet]
	public IActionResult Products2()
	{

		return View();
	}
}