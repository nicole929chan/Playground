﻿using Microsoft.Extensions.Options;
using Repository;
using Service;
using Service.Services.Cart.Availibility;
using System.Text;
using WebApi.DelegatingHandlers;
using WebApi.GitHub.Api;
var builder = WebApplication.CreateBuilder(args);

Console.OutputEncoding = Encoding.UTF8;
//builder.Services.AddTransient<GlobalExceptionHandler>();

builder.Services.AddScoped<IAvailabilityService>(provider =>
{
    return new PurchaseLimitFeature(
        new QuantityLimitFeature(
            new AvailabilityService()));
});

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient("github", (serviceProvider, client) =>
{
    var settings = serviceProvider
        .GetRequiredService<IOptions<GitHubSettings>>().Value;

    client.DefaultRequestHeaders.Add("Authorization", settings.AccessToken);
    client.DefaultRequestHeaders.Add("User-Agent", settings.UserAgent);

    client.BaseAddress = new Uri("https://api.github.com");
})
    .AddHttpMessageHandler<LoggingHandler>();

builder.Services.AddTransient<GitHubService>();
builder.Services.AddTransient<LoggingHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 放在ap之前, 若ap出现異常, ap返回的例外信息會被此處攔截
//app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();
