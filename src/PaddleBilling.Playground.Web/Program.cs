using PaddleBilling.Core.API.v1.Resources.Customers;
using PaddleBilling.Core.API.v1.Resources.Enums;
using PaddleBilling.Playground.Web.Handlers;
using PaddleBilling.Webhooks.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPaddleWebhooks(config =>
{
    config.SetEndpoint("/api/webhooks");
    config.AddHandler<AddressCreatedHandler>(EventType.AddressCreated);
});


var app = builder.Build();

app.UsePaddleWebhooks();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
