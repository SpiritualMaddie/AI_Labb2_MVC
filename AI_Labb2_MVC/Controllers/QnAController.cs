using Azure.AI.Language.QuestionAnswering;
using Azure.AI.TextAnalytics;
using Azure;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace AI_Labb2_MVC.Controllers
{
    public class QnAController : Controller
    {
        //private static TextAnalyticsClient? _textAnalyticsClient;
        //private static QuestionAnsweringClient? _qnaClient;
        //private static QuestionAnsweringProject? _qnaProject;

        //private IConfiguration _config;
        //public QnAController(IConfiguration configuration)
        //{
        //    _config = configuration;
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult QnAbot()
        //{
        //    // Get config values
        //    string? cogSvcEndpoint = _config["CognitiveServicesEndpoint"];
        //    string? cogSvcKey = _config["CognitiveServiceKey"];
        //    string? qnAKey = _config["QnAKey"];
        //    string? languageEndpoint = _config["RuntimeEndpoint"];
        //    string? projectName = _config["ProjectName"];
        //    string? deploymentName = _config["DeploymentName"];

        //    // Initialize clients
        //    _textAnalyticsClient = new TextAnalyticsClient(new Uri(cogSvcEndpoint), new AzureKeyCredential(cogSvcKey));
        //    _qnaClient = new QuestionAnsweringClient(new Uri(languageEndpoint), new AzureKeyCredential(qnAKey));
        //    _qnaProject = new QuestionAnsweringProject(projectName, deploymentName);


        //    // ******************** Chatting app starts here **************************
        //    try
        //    {

        //        // *****************************Take user input*****************************
        //        // Get user input (until they enter "quit")
        //        string userText = "";
        //        while (userText.ToLower() != "quit")
        //        {
        //            // Set encoding to unicode
        //            Console.InputEncoding = Encoding.Unicode;
        //            Console.OutputEncoding = Encoding.Unicode;

        //            Console.WriteLine("\nPlease ask a question \n('quit' to stop)");
        //            userText = Console.ReadLine();

        //            if (userText.ToLower() != "quit")
        //            {
        //                // Call function to ask Custom Question Answering
        //                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //                string response = AskQuestion(userText);
        //                Console.WriteLine(Application.WrapText(response, 47));

        //                // Call function to detect language
        //                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //                string language = GetLanguage(userText);
        //                Console.WriteLine("Language: " + language);

        //                // Call function to detect sentiment
        //                string sentiment = GetSentiment(userText);
        //                Console.WriteLine("Sentiment: " + sentiment);
        //                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex.Message);
        //    }
        //    return View();
        //}

        //static string AskQuestion(string userText)
        //{
        //    // Query the QnA bot
        //    Response<AnswersResult> response = _qnaClient.GetAnswers(userText, _qnaProject);

        //    // If there's an answer & the confidence score is above 0.70 return it; otherwise, provide a default response.
        //    if (response.Value.Answers.Count > 0 && response.Value.Answers[0].Confidence > 0.70)
        //    {
        //        return response.Value.Answers[0].Answer;
        //    }
        //    else
        //    {
        //        return "I'm sorry, I don't have an answer to that.";
        //    }
        //}

        //static string GetLanguage(string text)
        //{
        //    // Call the service to get the detected language
        //    DetectedLanguage detectedLanguage = _textAnalyticsClient.DetectLanguage(text);
        //    return detectedLanguage.Name;
        //}

        //static string GetSentiment(string text)
        //{
        //    // Call the service to get the detected sentiment
        //    DocumentSentiment sentimentAnalysis = _textAnalyticsClient.AnalyzeSentiment(text);
        //    return sentimentAnalysis.Sentiment.ToString();
        //}
    }
}
