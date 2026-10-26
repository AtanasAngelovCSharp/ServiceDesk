using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Services;
using ServiceDesk.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
builder.Services.AddScoped<ITechnicianService, TechnicianService>();

builder.Services.AddControllersWithViews(options =>
{
    // Bulgarian texts for the built-in model binding errors (empty or non-numeric values)
    var messages = options.ModelBindingMessageProvider;
    messages.SetValueMustNotBeNullAccessor(_ => "Полето е задължително.");
    messages.SetMissingBindRequiredValueAccessor(_ => "Полето е задължително.");
    messages.SetAttemptedValueIsInvalidAccessor((value, _) => $"Стойността „{value}“ е невалидна.");
    messages.SetValueIsInvalidAccessor(value => $"Стойността „{value}“ е невалидна.");
    messages.SetValueMustBeANumberAccessor(_ => "Полето трябва да е число.");
    messages.SetNonPropertyAttemptedValueIsInvalidAccessor(value => $"Стойността „{value}“ е невалидна.");
    messages.SetNonPropertyValueMustBeANumberAccessor(() => "Полето трябва да е число.");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
