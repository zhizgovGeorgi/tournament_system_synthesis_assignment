using DAL;
using LogicLayer;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<ITournamentDB<Tournament>, TournamentDB>();
builder.Services.AddTransient<IUserDB<User>, UserDB>();
builder.Services.AddTransient<IMatchDB<Match>, MatchDB>();
builder.Services.AddTransient<ITournamentManager, TournamentManager>();
builder.Services.AddTransient<IUserManger, UserManager>();
builder.Services.AddTransient<IMatchManager, MatchManager>();









// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(240);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; ;
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
options =>
{



    options.LoginPath = "/login";
    options.AccessDeniedPath = "/index";
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



app.UseAuthentication();
app.UseAuthorization();



app.MapRazorPages();



app.Run();
app.UseSession();