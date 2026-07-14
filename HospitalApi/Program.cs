using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string cvFilePath = @"D:\C#\HospitalProjClone\bin\Debug\net8.0\CV.txt";

app.MapGet("/api/cv/approve/{id}", (string id) => UpdateStatus(id, "Approved"));
app.MapGet("/api/cv/reject/{id}", (string id) => UpdateStatus(id, "Rejected"));

IResult UpdateStatus(string id, string newStatus)
{
    if (!File.Exists(cvFilePath))
        return Results.Content("<h2>CV.txt could not find</h2>", "text/html");

    string content = File.ReadAllText(cvFilePath);
    string[] blocks = content.Split("======================================", StringSplitOptions.RemoveEmptyEntries);

    bool found = false;
    for (int i = 0; i < blocks.Length; i++)
    {
        if (blocks[i].Contains($"Id: {id}"))
        {
            blocks[i] = Regex.Replace(blocks[i], @"Status:\s*\w+", $"Status: {newStatus}");
            found = true;
        }
    }

    if (!found)
        return Results.Content("<h2>CV could not find</h2>", "text/html");

    File.WriteAllText(cvFilePath, string.Join("======================================", blocks) + "======================================");

    return Results.Content($"<h2 style='color:{(newStatus == "Approved" ? "green" : "red")}'>CV {newStatus}!</h2>", "text/html");
}

app.Run();