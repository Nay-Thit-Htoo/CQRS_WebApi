using MassTransit;
using Microsoft.Extensions.Hosting;
using RabbitMq_MassTransit_CQRS.Consumer;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<MessageConsumer>();

            busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
            {
                busFactoryConfigurator.Host("rabbitmq", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                Console.WriteLine("Listening for producer messages...");

                busFactoryConfigurator.ReceiveEndpoint("receive-message", e =>
                {
                    e.ConfigureConsumer<MessageConsumer>(context);
                });
            });
        });

        // Ensure the MassTransit service is hosted properly
        services.AddMassTransitHostedService();
    });

var host = builder.Build();
await host.RunAsync();
