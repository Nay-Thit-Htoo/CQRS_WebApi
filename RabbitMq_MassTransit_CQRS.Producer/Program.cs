using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMq_MassTransit_CQRS.Producer;
using RabbitMq_MassTransit_CQRS.Producer.RabbitMQ;
using RabbitMq_MassTransit_CQRS.Producer.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();
builder.Services.AddScoped<IBillerService, BillerService>();
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
    {
        busFactoryConfigurator.Host("rabbitmq", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(System.Net.IPAddress.Any, 8080);
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healthz");
app.UseForwardedHeaders();

app.Run();