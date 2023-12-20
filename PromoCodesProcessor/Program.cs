using Microsoft.EntityFrameworkCore;
using PromoCodesProcessor;
using PromoCodesProcessor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbConnection>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSQL"))
);


builder.Services.AddControllers();


// Services used in the project
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<Promo_CodesService>();
builder.Services.AddScoped<UsersService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            //builder.WithOrigins(new[] { "http://localhost:5238/" });
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//.............



var app = builder.Build();


app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
