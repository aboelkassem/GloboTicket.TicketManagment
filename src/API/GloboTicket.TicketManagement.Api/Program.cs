using GloboTicket.TicketManagement.Api;
using Serilog;

Log.Information("GloboTicket API starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
      (context, services, configuration) => configuration
          .ReadFrom.Configuration(context.Configuration)
          .ReadFrom.Services(services)
          .Enrich.FromLogContext()
          .WriteTo.Console(),
      true
  );

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

app.UseSerilogRequestLogging();

//await app.ResetDatabaseAsync();

app.Run();
