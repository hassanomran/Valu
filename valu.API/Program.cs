using valu.BLL;
using valu.DAL;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDALServices(config);
builder.Services.RegisterBllServices();
builder.Services.AddCors(options =>
{
    var allowOriginPortal = config.GetValue<string>("Settings:AllowedOrginPortal");
    options.AddPolicy(name: "AllowOrigin",
                      builder =>
                      {
                          builder.WithOrigins(allowOriginPortal)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                      });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseCors("AllowOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
