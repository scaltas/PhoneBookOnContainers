using System.Text.Json.Serialization;
using Report.API.Events;
using Report.API.Infrastructure.Mongo;
using Report.API.Infrastructure.Reporting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMongoDbServices(builder.Configuration);
builder.Services.AddSingleton(sp => RabbitHutch.CreateBus("rabbitmq"));
builder.Services.AddHostedService<ReportingService>();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
