using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Cognitive.CustomVision.Training;
using Microsoft.Cognitive.CustomVision.Training.Models;

namespace CustomVision.Training
{
  public class Program
  {
    protected Program() { }

    public static void Main(string[] args)
    {
      var trainingApi = new TrainingApi
      {
        ApiKey = ConfigurationManager.AppSettings["trainingKey"]
      };

      var projectName = ConfigurationManager.AppSettings["projectName"];
      var project = trainingApi.GetProjects().Single(p => p.Name == projectName);

      UploadTrainingData(project.Id, trainingApi);
      TrainClassifier(project.Id, trainingApi);

      Console.ReadKey();
    }

    private static void UploadTrainingData(Guid projectId, TrainingApi trainingApi)
    {
      Console.WriteLine("Uploading images");
      foreach (var tagName in new[] { "surface-pro", "surface-studio" })
      {
        var tag = trainingApi.CreateTag(projectId, tagName);

        var images = Directory.GetFiles($@"..\..\..\..\dataset\Training\{tagName}")
          .Select(f => new ImageFileCreateEntry(Path.GetFileName(f), File.ReadAllBytes(f)))
          .ToList();

        var batch = new ImageFileCreateBatch(images, new List<Guid> { tag.Id });
        trainingApi.CreateImagesFromFiles(projectId, batch);
      }
    }

    private static void TrainClassifier(Guid projectId, TrainingApi trainingApi)
    {
      Console.WriteLine("Training classifier");

      var iteration = trainingApi.TrainProject(projectId);
      while (iteration.Status == "Training")
      {
        Thread.Sleep(1000);
        iteration = trainingApi.GetIteration(projectId, iteration.Id);
      }

      // Make the newly trained version the default for RESTful API requests
      iteration.IsDefault = true;
      trainingApi.UpdateIteration(projectId, iteration.Id, iteration);

      Console.WriteLine("Training complete. Press any key to exit.");
    }
  }
}