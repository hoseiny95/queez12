using HW10._2.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

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
//app.Use(async (ctx, next) =>
//{
//    var log = new Log(ctx.Request.Path);
//    await next();
//    log.resultStatusCode = ctx.Response.StatusCode;
//    var filepath = System.Environment.CurrentDirectory + "\\log.txt";
//    using (var writer = File.AppendText(filepath))
//    {
//        writer.WriteLine($"time:  {log.timestamp} ,  statusCode: {log.resultStatusCode}");
//    }
//    await next();
//}
//);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
