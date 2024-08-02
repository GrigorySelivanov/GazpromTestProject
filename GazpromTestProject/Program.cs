using Microsoft.EntityFrameworkCore;
using DbContext;
using System;
using DbContext.Repository;
using GazpromTestProject.Services.IServices;
using GazpromTestProject.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Repos
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IProviderService, ProviderService>();

//Services
builder.Services.AddScoped<OfferRepository>();
builder.Services.AddScoped<ProviderRepository>();

builder.Services.AddDbContext<AppDbContext>(a =>
{
    a.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        app.Logger.LogError("{}", ex.Message);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
