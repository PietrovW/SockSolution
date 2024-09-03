using AspireAppSock.ApiService.Infrastructure;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;
using Serilog.Formatting.OpenSearch;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using Serilog.Sinks.OpenSearch;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, services, config) =>
{
    config
    .MinimumLevel.Information()
    .Enrich.WithMachineName()
    .WriteTo.Console(new ElasticsearchJsonFormatter())
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions( new Uri("http://localhost:9200"))
    {
        FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
       
        AutoRegisterTemplate = true,
       // CustomFormatter =new ExceptionAsObjectJsonFormatter(renderMessage:true),
        BufferIndexDecider =(logEvent,offset) =>"log-serilo-sock-"+(new Random().Next(0,2)),
        //ModifyConnectionSettings =x=>x.BasicAuthentication(username:"admin",password: "myStrongPassword123@456")
    }
    )

    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
.ReadFrom.Configuration(context.Configuration);
});


builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();

app.UseExceptionHandler();
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.SeedDatabase();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        //c.RoutePrefix = "";
    });
}

app.MapDefaultEndpoints();
app.MapControllers();
app.Run();

