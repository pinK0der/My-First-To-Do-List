using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

var builder = WebApplication.CreateBuilder(args);

// Додавання служб до контейнера
builder.Services.AddControllersWithViews();

// Налаштування контексту бази даних
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Налаштування проміжного програмного забезпечення (middleware)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
*/
//app.MapControllerRoute(name: "name_age", pattern: "{controller}/{action}");

app.Run();