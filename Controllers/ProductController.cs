using creWin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace creWin.Controllers
{
    public class ProductController : Controller
    {

        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /*public async Task<IActionResult> Contact()
        {
            var categoriesResponse = await _httpClient.GetStringAsync("https://dummyjson.com/products/categories");
            var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesResponse);
            return View(categories);
        }*/

        /*public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/products/categories");

            if (response.IsSuccessStatusCode)
            {
                var categoriesJson = await response.Content.ReadAsStringAsync();

                // JSON verisini deserialize ediyoruz
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

                // Konsola yazdırarak gelen kategorilerin doğru gelip gelmediğini kontrol edin
                if (categories == null || !categories.Any())
                {
                    Console.WriteLine("Kategori listesi boş.");
                }
                else
                {
                    Console.WriteLine($"Kategori sayısı: {categories.Count}");
                }

                return View(categories); // Modeli view'a gönderiyoruz
            }
            else
            {
                ViewBag.ErrorMessage = $"API hatası: {response.StatusCode}";
                return View(new List<Category>()); // Hata durumunda boş liste döndürüyoruz
            }
        }*/

        public async Task<IActionResult> Categories()
        {
            try
            {
                var apiUrl = "https://dummyjson.com/products/categories";
                var response = await _httpClient.GetStringAsync(apiUrl);

                // Konsolda API'den gelen veriyi kontrol et
                Console.WriteLine("API Response: " + response);

                var categories = JsonConvert.DeserializeObject<List<Category>>(response);

                return View(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return View(new List<string>());  // Hata durumunda boş liste döndür
            }
        }





    }
}
