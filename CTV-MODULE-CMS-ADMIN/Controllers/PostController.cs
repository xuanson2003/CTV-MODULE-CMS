using CTV_MODULE_CMS_ADMIN.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace CTV_MODULE_CMS_ADMIN.Controllers
{
	public class PostController : Controller
	{
		private static readonly HttpClient _httpClient = new HttpClient();

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreatingPost creatingPost)
		{
			var postModel = new
			{
				Id = Guid.NewGuid().ToString(),
				Title =creatingPost.Title,
				Desc = creatingPost.Desc,
				Content = creatingPost.Content,
				IsHot = creatingPost.IsHot ?? false,
				Source = creatingPost.Source,
				IsActive = true,
				Avatar = creatingPost.Avatar, // Your IFormFile instance here if needed
				Status = "chua_duyet"
			};

			var apiUrl = "http://localhost:5050/api/CMS_Post/add-item"; // Replace with your API endpoint

			// Serialize the model to JSON
			var json = JsonSerializer.Serialize(postModel);

			// Create the HTTP content with JSON
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			// Send the POST request
			var response = await _httpClient.PostAsync(apiUrl, content);

			// Check if the request was successful
			if (response.IsSuccessStatusCode)
			{
				Console.WriteLine("Post successfully created.");
			}
			else
			{
				Console.WriteLine($"Failed to create post. Status code: {response.StatusCode}");
			}
			return NoContent();
		}

		public IActionResult Edit()
		{
			return View();
		}
	}
}
