using Microsoft.EntityFrameworkCore;
using EcoCharge.adapter.output.database;
using EcoCharge.adapter.input;
using EcoCharge.domain.useCase;
using EcoCharge.domain.repository;
using FluentValidation;
using EcoCharge.adapter.input.dtos;
using EcoCharge.domain.model;
using EcoCharge.domain.useCase.dto;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.validator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.Load();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseOracle(
        "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))\n(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=RM97707;Password=220600;");
});

builder.Services.AddControllers();

// VEHICLE
builder.Services.AddScoped<IVehicleAdapter, VehicleAdapter>();
builder.Services.AddScoped<IVehicleUseCase, VehicleUseCase>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddScoped<IValidator<Vehicle>, VehicleValidator>();

// USER
builder.Services.AddScoped<IUserAdapter, UserAdapter>();
builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IValidator<User>, UserValidator>();

// TRAVEL
builder.Services.AddScoped<ITravelAdapter, TravelAdapter>();
builder.Services.AddScoped<ITravelUseCase, TravelUseCase>();
builder.Services.AddScoped<ITravelRepository, TravelRepository>();

builder.Services.AddScoped<IValidator<Travel>, TravelValidator>();

// CHARGING POST
builder.Services.AddScoped<IChargingPostAdapter, ChargingPostAdapter>();
builder.Services.AddScoped<IChargingPostUseCase, ChargingPostUseCase>();
builder.Services.AddScoped<IChargingPostRepository, ChargingPostRepository>();

builder.Services.AddScoped<IValidator<ChargingPost>, ChargingPostValidator>();

// CHARGING POINT
builder.Services.AddScoped<IChargingPointAdapter, ChargingPointAdapter>();
builder.Services.AddScoped<IChargingPointUseCase, ChargingPointUseCase>();
builder.Services.AddScoped<IChargingPointRepository, ChargingPointRepository>();

builder.Services.AddScoped<IValidator<ChargingPoint>, ChargingPointValidator>();

// BOOKING
builder.Services.AddScoped<IBookingAdapter, BookingAdapter>();
builder.Services.AddScoped<IBookingUseCase, BookingUseCase>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IValidator<Booking>, BookingValidator>();

// CHARGING HISTORY
builder.Services.AddScoped<IChargingHistoryAdapter, ChargingHistoryAdapter>();
builder.Services.AddScoped<IChargingHistoryUseCase, ChargingHistoryUseCase>();
builder.Services.AddScoped<IChargingHistoryRepository, ChargingHistoryRepository>();

builder.Services.AddScoped<IValidator<ChargingHistory>, ChargingHistoryValidator>();

// EVALUATION
builder.Services.AddScoped<IEvaluationAdapter, EvaluationAdapter>();
builder.Services.AddScoped<IEvaluationUseCase, EvaluationUseCase>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();

builder.Services.AddScoped<IValidator<Evaluation>, EvaluationValidator>();

// STOPING POINT
builder.Services.AddScoped<IStopingPointAdapter, StopingPointAdapter>();
builder.Services.AddScoped<IStopingPointUseCase, StopingPointUseCase>();
builder.Services.AddScoped<IStopingPointRepository, StopingPointRepository>();

builder.Services.AddScoped<IValidator<StopingPoint>, StopingPointValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoCharge API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
