using creWin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace creWin.Controllers
{
    public class ProductController : Controller
    {
        Uri baseAdresses = new Uri("https://dummyjson.com/");
        
        private readonly HttpClient _client;
        
        public ProductController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdresses;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var url = "https://dummyjson.com/products/categories";
                Debug.WriteLine($"Requesting URL: {url}"); // Debug log ekleyelim

                var response = await _client.GetAsync(url);
                Debug.WriteLine($"Response Status: {response.StatusCode}"); // Status kodu görelim

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Response Data: {data}"); // Gelen veriyi görelim
                    var categories = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                    return View(categories);
                }

                Debug.WriteLine("Request failed"); // Hata durumunda log
                return View(new List<string>());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}"); // Hata mesajını görelim
                return View(new List<string>());
            }
        }
    }
}
