using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using Test_webAPI_USERS.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

string forCors = "MYsettingCORS"??null;

builder.Services.AddCors(option =>
{
	option.AddPolicy(forCors, policy =>
	{
		policy.AllowAnyHeader()
		.AllowAnyMethod()
		.AllowCredentials()
		.SetIsOriginAllowed((host) => true);
		//.WithOrigins("Url/WebSites");
	});
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBcontext>();
builder.Services.AddScoped<IDataRepository,DataRepositories>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(SwaggerBuilderExtensions =>
{
	SwaggerBuilderExtensions.SwaggerDoc("v1", 
		new OpenApiInfo { 
		Title = "Задание для C# developers",
		Version ="v1",
		Description= "Написать Web API сервис на .NET Core 3.1 или выше, реализующий API методы CRUD над \r\nсущностью Users, доступ к API должен осуществляться через интерфейс Swagger.",
		Contact = new OpenApiContact { 
			Name = "Oyatullo",
			Email="oyatullo.sangov1998@mail.ru",
			Url=new Uri("http://oyatullo.ru")}
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(
	SwaggerUIOptions =>
	{
		SwaggerUIOptions.DocumentTitle = "Задание для C# developers";
		SwaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Users");
		SwaggerUIOptions.RoutePrefix = "swagger";

	});

/*if (app.Environment.IsDevelopment())
{
	
}*/
app.UseCors(forCors);
//app.MapGet("/get-all-users", async () => await DataRepositories.GetUsers()).WithTags("Создание пользователя");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
