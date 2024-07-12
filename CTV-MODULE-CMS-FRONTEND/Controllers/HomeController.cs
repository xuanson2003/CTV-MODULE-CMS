using CTV_MODULE_CMS_FRONTEND.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using CTV_MODULE_CMS_FRONTEND.Models.CMS;
using CTV_MODULE_CMS_FRONTEND.Models.ViewModel;
using Newtonsoft.Json;

namespace CTV_MODULE_CMS_FRONTEND.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       /* public IActionResult Index()
        {
            return View();
        }*/

        public async Task<IActionResult> Index()
        {
            List<cms_post> topPost = new List<cms_post>();
            List<cms_post> newsPost = new List<cms_post>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5050/api/CMS_Post/get-top-post"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);
                    topPost = responseData.Data;
                }

                using (var response = await httpClient.GetAsync("http://localhost:5050/api/CMS_Post/get-news-post"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);
                    newsPost = responseData.Data;
                }
            }

            view_index_model viewModel = new view_index_model(topPost, newsPost);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

public class ApiResponse
{
    public List<cms_post> Data { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
}

