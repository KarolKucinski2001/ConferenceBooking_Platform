using ConferenceBooking.WebAPi.Middleware;
using ConferenceBooking.Application.Mappings;
using ConferenceBooking.Infrastructure.Repositories;
using ConferenceBooking.Infrastructure;
using ConferenceBooking.WebAPi.Middleware;
using ConferenceBooking.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using NLog.Web;
using NLog;
using Microsoft.EntityFrameworkCore;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Application.Services.Generic;
using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.SharedKernel.Dto.Room;
using ConferenceBooking.Application.Validators.Room;




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
           .UseSqlite("Data Source=../conference.db")
           .Options;

    // Tworzenie i inicjalizacja bazy danych
    using (var context = new ConferenceDbContext(options))
    {
        // Usuwanie istniej¹cej bazy i tworzenie nowej dla celów demonstracyjnych
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    // rejestracja kontekstu bazy w kontenerze IoC
    //ar sqliteConnectionString = "Data Source=Kiosk.WebAPI.Logger.db";
    var sqliteConnectionString = @"Data Source=ConferenceBooking_Platform";
    builder.Services.AddDbContext<ConferenceDbContext>(options =>
        options.UseSqlite(sqliteConnectionString));



    // rejestracja walidatora
    builder.Services.AddScoped<IValidator<CreateRoomDto>, RegisterCreateRoomDtoValidator>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IRoomRepository, RoomRepository>();
    builder.Services.AddScoped<DataSeeder>();
    builder.Services.AddScoped<IRoomService, RoomService>();

    builder.Services.AddScoped<IBookingRepository, BookingRepository>();
    builder.Services.AddScoped<IBookingService, BookingService>();



    builder.Services.AddScoped<ExceptionMiddleware>();


    // rejestruje w kontenerze zale¿noœci politykê CORS o nazwie SaleKioks,
    // która zapewnia dostêp do API z dowolnego miejsca oraz przy pomocy dowolnej metody
    builder.Services.AddCors(o => o.AddPolicy("ConferenceBooking", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();


    // wstawia politykê CORS obs³ugi do potoku ¿¹dania
    app.UseCors("ConferenceBooking");

    // seeding data
    using (var scope = app.Services.CreateScope())
    {
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        dataSeeder.Seed();
    }



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

