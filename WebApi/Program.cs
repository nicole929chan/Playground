using Repository;
using Service;
using WebApi.Middlewares;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GlobalExceptionHandler>();

// Add services to the container.
builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();
