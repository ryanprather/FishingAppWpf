using FishingApp.Client.ViewModels.MainWindow;
using FishingApp.Storage.Context;
using FishingApp.Storage.Service.NoaaService;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace FishingApp.Client
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        internal FlowDirection InitialFlowDirection { get; set; }
        internal BaseTheme InitialTheme { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = CreateServices();
            using (var db = new FishingAppContext())
            {
                db.Database.Migrate();
            }
            
            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private ServiceProvider CreateServices()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            var databaseConnectionString = Configuration.GetConnectionString("FishingAppSqliteDatabaseConn");
            var noaaLocation = Configuration.GetConnectionString("NoaaActiveStations");
            var noaaQueryString = Configuration.GetConnectionString("NoaaQueryString"); 

            var serviceProvider = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            serviceProvider.AddScoped<IMainWindowViewModel, MainWindowViewModel>();
            serviceProvider.AddDbContext<FishingAppContext>(options => options.UseSqlite(databaseConnectionString));
            serviceProvider.AddScoped<INoaaQueryService>(s => new NoaaQueryService(noaaLocation, noaaQueryString));
            serviceProvider.AddScoped<MainWindow>();

            return serviceProvider.BuildServiceProvider();
        }
    }

}
