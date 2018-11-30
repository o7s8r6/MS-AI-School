using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Cognitive.CustomVision.Prediction;
using Microsoft.Cognitive.CustomVision.Training;

namespace CustomVision.Prediction
{
  public class Program
  {
    protected Program() { }

    public static void Main(string[] args)
    {
      var projectId = GetProjectId();
      var endpoint = GetPredictionEndpoint();

      Console.WriteLine("Testing images");
      foreach (var tagName in new[] { "surface-pro", "surface-studio" })
      {
        var images = Directory.GetFiles($@"..\..\..\..\dataset\Prediction\{tagName}");
        foreach (var image in images)
        {
          var memoryStream = new MemoryStream(File.ReadAllBytes(image));
          var prediction = endpoint.PredictImage(projectId, memoryStream);

          var topPrediction = prediction.Predictions.First();
          Console.WriteLine($"{image} predicted to be {topPrediction.Tag} ({topPrediction.Probability:P1})");
        }
      }

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
    }

    private static Guid GetProjectId()
    {
      var trainingApi = new TrainingApi
      {
        ApiKey = ConfigurationManager.AppSettings["trainingKey"]
      };

      var projectName = ConfigurationManager.AppSettings["projectName"];
      var project = trainingApi.GetProjects().Single(p => p.Name == projectName);

      return project.Id;
    }

    private static PredictionEndpoint GetPredictionEndpoint()
    {
      var predictionEndpoint = new PredictionEndpoint
      {
        ApiKey = ConfigurationManager.AppSettings["predictionKey"]
      };

      return predictionEndpoint;
    }
  }
}