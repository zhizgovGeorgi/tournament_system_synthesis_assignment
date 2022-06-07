using DAL;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ITournamentDB<Tournament>, TournamentDB>();
builder.Services.AddScoped<IMatchDB<Match>, MatchDB>();
builder.Services.AddScoped<IUserDB<User>, UserDB>();
builder.Services.AddScoped<IUserManger, UserManager>();
builder.Services.AddScoped<IMatchManager, MatchManager>();
builder.Services.AddScoped<ITournamentManager, TournamentManager>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(240);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; ;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Error";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
app.UseSession();
