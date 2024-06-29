using ConferenceBooking.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using ConferenceBooking.Domain.Contracts;
using ConferenceBooking.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ConferenceBooking.Application.Services.Generic;
using ConferenceBooking.Application.Services.Interfaces;
using ConferenceBooking.SharedKernel.Dto.Room;
using ConferenceBooking.Application.Validators.Room;
using NLog.Web;
using ConferenceBooking.Application.Validators.Booking;
using ConferenceBooking.Application.Validators.Equipment;
using ConferenceBooking.Application.Validators.User;
using ConferenceBooking.Infrastructure.Repositories;
using ConferenceBooking.SharedKernel.Dto.Booking;
using ConferenceBooking.SharedKernel.Dto.Equipment;
using ConferenceBooking.SharedKernel.Dto.User;
using NLog;



// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();


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
    builder.Services.AddScoped<IValidator<UpdateRoomDto>, RegisterUpdateRoomDtoValidator>();

    builder.Services.AddScoped<IValidator<CreateEquipmentDto>, RegisterCreateEquipmentDtoValidator>();
    builder.Services.AddScoped<IValidator<UpdateEquipmentDto>, RegisterUpdateEquipmentDtoValidator>();

    builder.Services.AddScoped<IValidator<CreateUserDto>, RegisterCreateUserDtoValidator>();
    builder.Services.AddScoped<IValidator<UpdateUserDto>, RegisterUpdateUserDtoValidator>();

    builder.Services.AddScoped<IValidator<CreateBookingDto>, RegisterCreateBookingDtoValidator>();
    builder.Services.AddScoped<IValidator<UpdateBookingDto>, RegisterUpdateBookingDtoValidator>();


    builder.Services.AddScoped<DataSeeder>();

    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



    builder.Services.AddScoped<IRoomService, RoomService>();
    builder.Services.AddScoped<IBookingService, BookingService>();
    builder.Services.AddScoped<IEquipmentService, EquipmentService>();
    builder.Services.AddScoped<IUserService, UserService>();



    builder.Services.AddScoped<IRoomRepository, RoomRepository>();
    builder.Services.AddScoped<IBookingRepository, BookingRepository>();
    builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");



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
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}



