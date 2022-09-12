using Microsoft.EntityFrameworkCore;
using WK.TechnicalTest.DAO;
using WK.TechnicalTest.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("AppLocal");
builder.Services.AddDbContext<DataDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.30-mysql"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ResolveDependencies(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
