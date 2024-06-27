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

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<DataSeeder>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

























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

app.Run();
