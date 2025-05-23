var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
    serverOptions.ListenAnyIP(Int32.Parse(port));
});

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
