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

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/products/categories");

            if (response.IsSuccessStatusCode)
            {
                var categoriesJson = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

                return View(categories); // Kategorileri View’a gönderiyoruz
            }
            else
            {
                // Hata durumunu ele alıyoruz
                ViewBag.ErrorMessage = "Kategoriler yüklenemedi.";
                return View(new List<Category>()); // Boş bir liste döndürüyoruz
            }
        }

    }
}
