using ConferenceBooking.WebAPi.Middleware;
using ConferenceBooking.Application.Mappings;
using ConferenceBooking.Infrastructure.Repositories;
using ConferenceBooking.Infrastructure;
//using ConferenceBooking.SharedKernel.Dto;
using ConferenceBooking.WebAPi.Middleware;
using ConferenceBooking.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
//using ConferenceBooking.Application.Validators;
using NLog.Web;
using NLog;
using Microsoft.EntityFrameworkCore;




// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // Add services to the container.

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();



    // rejestracja automappera w kontenerze IoC
    builder.Services.AddAutoMapper(typeof(ConferenceBookingMappingProfile));

    // rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przez ModelState)
    builder.Services.AddFluentValidationAutoValidation();


    var options = new DbContextOptionsBuilder<ConferenceDbContext>()
           .UseSqlite("Data Source=conference.db")
           .Options;

    // Tworzenie i inicjalizacja bazy danych
    using (var context = new ConferenceDbContext(options))
    {
        // Usuwanie istniej¹cej bazy i tworzenie nowej dla celów demonstracyjnych
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

        // rejestracja kontekstu bazy w kontenerze IoC
        // var sqliteConnectionString = "Data Source=Kiosk.WebAPI.Logger.db";
    //    var sqliteConnectionString = @"Data Source=C:\Users\karol\OneDrive\Pulpit\ConferenceRoomBookingSystem\ConferenceBooking_Platform";
    //builder.Services.AddDbContext<ConferenceDbContext>(options =>
    //    options.UseSqlite(sqliteConnectionString));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

