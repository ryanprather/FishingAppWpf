using FishingApp.Client.UserControls;
using FishingApp.Client.ViewModels.MainWindow;
using FishingApp.Client.ViewModels.NoaaList;
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

        public IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }
        internal FlowDirection InitialFlowDirection { get; set; }
        internal BaseTheme InitialTheme { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceProvider = CreateServices();
            using (var dbContext = ServiceProvider.GetRequiredService<FishingAppContext>()) 
            {
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
            }

            MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
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

            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddDbContext<FishingAppContext>(options => options.UseSqlite(databaseConnectionString));
            serviceCollection.AddScoped<INoaaQueryService>(s => new NoaaQueryService(noaaLocation, noaaQueryString));
            
            serviceCollection.AddScoped<INoaaListViewModel, NoaaListViewModel>();
            serviceCollection.AddScoped<IMainWindowViewModel>(s => new MainWindowViewModel(typeof(uc_NoaaList).Namespace));
            serviceCollection.AddScoped<MainWindow>();
            serviceCollection.AddScoped<uc_NoaaList>();
            serviceCollection.AddScoped<uc_Dashboard>();

            return serviceCollection.BuildServiceProvider();
        }
    }

}
