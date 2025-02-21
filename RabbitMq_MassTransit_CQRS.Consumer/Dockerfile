# Use the official .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ./RabbitMq_MassTransit_CQRS.Consumer/RabbitMq_MassTransit_CQRS.Consumer.csproj ./RabbitMq_MassTransit_CQRS.Consumer/
RUN dotnet restore ./RabbitMq_MassTransit_CQRS.Consumer/RabbitMq_MassTransit_CQRS.Consumer.csproj

# Copy the entire project and build it
COPY . .
WORKDIR /src/RabbitMq_MassTransit_CQRS.Consumer
RUN dotnet build ./RabbitMq_MassTransit_CQRS.Consumer.csproj -c Release -o /app/build

# Publish the application
RUN dotnet publish ./RabbitMq_MassTransit_CQRS.Consumer.csproj -c Release -o /app/publish

# Use the official .NET runtime image to create the final image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base

# Set the working directory
WORKDIR /app

# Copy the built application from the build stage
COPY --from=build /app/publish .


# Define the entry point for the application
ENTRYPOINT ["dotnet", "RabbitMq_MassTransit_CQRS.Consumer.dll"]