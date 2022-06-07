using DAL;
using LogicLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TournamentDesktopApplication
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new DesktopApp());
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<TournamentDesktopApplication.DesktopApp>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ITournamentDB<Tournament>, TournamentDB>();
                    services.AddTransient<ITournamentManager, TournamentManager>();
                    services.AddTransient<IUserDB<User>, UserDB>();
                    services.AddTransient<IUserManger, UserManager>();
                    services.AddTransient<IMatchDB<Match>, MatchDB>();
                    services.AddTransient<IMatchManager, MatchManager>();
                    services.AddTransient<TournamentDesktopApplication.Forms.TournamentManagement>();
                    services.AddTransient<TournamentDesktopApplication.DesktopApp>();
                });
        }
    }
}