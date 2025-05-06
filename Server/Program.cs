using System.Xml;
using BL;
using BL.Api;
using Dal;
using Dal.Api;

var builder = WebApplication.CreateBuilder(args);
// �����
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", // Policy name
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Replace with your frontend's URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
}); ;
// ���� ������������� ���� appsettings.json
var configuration = builder.Configuration;
var baseUrl = configuration["BaseUrl"];
var port = configuration["Port"];

// ����� ������ JSON �� ReferenceHandler.Preserve
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// ����� ������� �-DI
builder.Services.AddSingleton<IDal, DalMannager>();
builder.Services.AddSingleton<IblMANanager, BlManager>();
builder.Services.AddControllers();

// ����� Base URL ������
if (!string.IsNullOrEmpty(baseUrl))
{
    builder.WebHost.UseUrls(baseUrl);
}

var app = builder.Build();
app.UseCors("AllowFrontend");
app.UseAuthorization();

// ����� Controllers
app.MapControllers();

// ���� ���������
app.Run();