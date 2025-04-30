using System.Xml;
using BL;
using BL.Api;
using Dal;
using Dal.Api;

var builder = WebApplication.CreateBuilder(args);
// ריאקט
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173") // הכתובת של אפליקציית React
               .AllowAnyHeader() // מאפשר כותרות מותאמות אישית
               .AllowAnyMethod(); // מאפשר כל סוגי הבקשות (GET, POST וכו')
    });
});
// גישה לקונפיגורציות מתוך appsettings.json
var configuration = builder.Configuration;
var baseUrl = configuration["BaseUrl"];
var port = configuration["Port"];

// הוספת הגדרות JSON עם ReferenceHandler.Preserve
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// רישום שירותים ל-DI
builder.Services.AddSingleton<IDal, DalMannager>();
builder.Services.AddSingleton<IblMANanager, BlManager>();
builder.Services.AddControllers();

// הגדרת Base URL והפורט
if (!string.IsNullOrEmpty(baseUrl))
{
    builder.WebHost.UseUrls(baseUrl);
}

var app = builder.Build();

// מיפוי Controllers
app.MapControllers();

// הרצת האפליקציה
app.Run();