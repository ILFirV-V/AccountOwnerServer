using AccountOwnerServer.Extensions;
using AccountOwnerServer.Middleware;
using Logging.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using Persistence.Extensions;
using Services.Extensions;
using Services.Mapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddExceptionHandler<DeleteOwnerWithAccountsExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.ConfigureLoggerService();


builder.Services.ConfigurePostgresqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();

builder.Services.ConfigureServices();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.Controllers.AccountController).Assembly)
    .AddApplicationPart(typeof(Presentation.Controllers.OwnerController).Assembly); ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
