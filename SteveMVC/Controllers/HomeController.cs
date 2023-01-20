using Microsoft.AspNetCore.Mvc;
using Steve.Model;
using Steve.Service;
using SteveMVC.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace SteveMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOpenAIService _openAIService;
        public HomeController(ILogger<HomeController> logger, IOpenAIService openAIService)
        {
            _logger = logger;
            _openAIService = openAIService;
        }

        public IActionResult Index()
        {
            if (Convert.ToInt32(HttpContext.Session.GetInt32(SessionKey.UserId)) == 0)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(OpenAIViewModel viewModel, IFormCollection form)
        {
            viewModel.UserId = Convert.ToInt32(HttpContext.Session.GetInt32(SessionKey.UserId));
            var result = await CreateCompletions(viewModel);
            if (result.IsSuccessStatusCode)
            {
                viewModel.Response = await result.Content.ReadAsStringAsync();
            }

            _openAIService.Save(viewModel);

            if (!string.IsNullOrEmpty(viewModel.Response))
            {
                OpenAIResponse openAIResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<OpenAIResponse>(viewModel.Response);
                if (openAIResponse.choices.Count() > 0)
                {
                    viewModel.Response = openAIResponse.choices[0].text;
                }
            }

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<HttpResponseMessage> CreateCompletions(OpenAIViewModel viewModel)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod(Constants.Post), OpenAIConfiguration.EndPoint))
                {
                    request.Headers.TryAddWithoutValidation(Constants.Authorization, $"Bearer {OpenAIConfiguration.APIKey}");
                    OpenAIRequestModel requestModel = new OpenAIRequestModel();
                    requestModel.model = OpenAIConfiguration.Model;
                    requestModel.max_tokens = 60;
                    requestModel.temperature = 0;
                    requestModel.top_p = 1.0;
                    requestModel.frequency_penalty = 0.0;
                    requestModel.presence_penalty = 0.0;
                    requestModel.prompt = $"{OpenAIConfiguration.PromptMessage}\n\n{viewModel.Request}";
                    request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(requestModel));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    return response;
                }
            }
        }
    }
}