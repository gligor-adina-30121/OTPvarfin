using otp1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string CORSOpenPolicy = "OpenCORSPolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(
  name: CORSOpenPolicy,
  builder => {
      builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
  });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IOneTimePasswordService, OneTimePasswordService>();
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



app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
