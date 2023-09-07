using AI_Labb2_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using static System.Net.Mime.MediaTypeNames;
using ImageUrl = Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models.ImageUrl;

namespace AI_Labb2_MVC.Controllers
{
    public class ImageSearchController : Controller
    {
        private static CustomVisionPredictionClient? _customVisionClient;
        private static TarotPredictionViewModel? viewModel;
        private IConfiguration _config;

        private string? firstPrediction;
        private string? secondPrediction;
        private string? errorMessage;

        public ImageSearchController(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TarotCheck(string userInput)
        {
            // Get config values
            string? custVKey = _config["CustomVisionKey"];
            string? custVEndPoint = _config["CustomVisionEndPoint"];
            string? custVProjectId = _config["CustomVisionProjectId"];
            string? custVModelName = _config["CustomVisionModelName"];

            // Initialize clients
            _customVisionClient = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(custVKey)) { Endpoint = custVEndPoint };

            // ******************** Function starts here **************************
            try
            {
                Guid projectId = new Guid(custVProjectId);

                var result = _customVisionClient.ClassifyImageUrl(projectId, custVModelName, new ImageUrl(userInput));

                // Top two cards with the highest probability
                var topTwoPredictions = result.Predictions.OrderByDescending(p => p.Probability).Take(2).ToList();

                if (topTwoPredictions.Any())
                {
                    if (topTwoPredictions[0].Probability > 0.80)
                    {
                        firstPrediction = $"Type of card: {topTwoPredictions[0].TagName}";

                        // Check if there's a second prediction and if its probability is also above the threshold
                        if (topTwoPredictions.Count > 1 && topTwoPredictions[1].Probability > 0.80)
                        {
                            secondPrediction = $"And I think it's a: {topTwoPredictions[1].TagName}";
                        }
                    }
                    else
                    {
                        errorMessage = "I'm not confident enough about this card. \nPlease try another image or ensure the image clearly depicts a tarot or oracle card.";
                    }
                }
                else
                {
                    errorMessage = "No predictions could be made.";
                }
                viewModel = new TarotPredictionViewModel
                {
                    FirstPrediction = firstPrediction,
                    SecondPrediction = secondPrediction,
                    ErrorMessage = errorMessage,
                    UserInputURL = userInput
                };
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return View(viewModel);
        }
    }
}
