using creWin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
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
                    var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);

                    var categoryModels = categories.Select(c => new CategoryViewModel
                    {
                        Slug = c.Slug,
                        Name = c.Name,
                        Url = Url.Action("Details", "Product", new { slug = c.Slug })
                    }).ToList();


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


        [HttpGet]
        [Route("Product/Details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return NotFound();
            }

            try
            {
                // API'ye gönderirken CategoryViewModel'den gelen slug'ı kullanıyoruz
                var url = $"https://dummyjson.com/products/category/{slug}";
                Debug.WriteLine($"Requesting URL: {url}");

                var response = await _client.GetAsync(url);
                Debug.WriteLine($"Response Status: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"Response Data: {data}");

                    var productsResponse = JsonConvert.DeserializeObject<ProductsResponse>(data);
                    return View(productsResponse.Products);
                }

                Debug.WriteLine("Request failed");
                return View(new List<ProductViewModel>());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
                return View(new List<ProductViewModel>());
            }
        }
    }

    public class ProductsResponse
    {
        [JsonProperty("products")]
        public List<ProductViewModel> Products { get; set; }
    }

}

