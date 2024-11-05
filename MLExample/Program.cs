// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

var question = new MLModel1.ModelInput()
{
    Col0 = "What a wonderful world!"
};

var answer = MLModel1.Predict(question);

var score = answer.Score;
Console.WriteLine($"");
