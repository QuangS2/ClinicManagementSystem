using Clinic.Application;
using Clinic.Application.Interfaces;
using Clinic.Application.Mappings;
using Clinic.Application.Services;
using Clinic.Infrastructure;
using Clinic.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Extension method from Application and Infrastructure layers
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);

// Add repositories
builder.Services.AddScoped<IPatientRepository,PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
// Auto Mapper Configurations
builder.Services.AddAutoMapper(cfg =>
{
    //cfg.AddMaps(typeof(MappingProfile).Assembly);
    cfg.AddProfile<MappingProfile>();
});

// Build the app
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();

