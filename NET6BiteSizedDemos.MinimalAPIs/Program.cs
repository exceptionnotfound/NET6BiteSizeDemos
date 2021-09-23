var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => "Hello Dear Reader!");

app.MapGet("/greet", () => "How are you today?");

app.Run();