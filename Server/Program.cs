using System.Xml;
using BL;
using BL.Api;
using Dal;
using Dal.Api;

var builder = WebApplication.CreateBuilder(args);
// �����
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173") // ������ �� ��������� React
               .AllowAnyHeader() // ����� ������ ������� �����
               .AllowAnyMethod(); // ����� �� ���� ������ (GET, POST ���')
    });
});
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

// ����� Controllers
app.MapControllers();

// ���� ���������
app.Run();