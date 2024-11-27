namespace ThosCase.Extension
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            StartupExtension.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddDbContexts();
            services.AddManagers();
            services.AddDataTables();
            services.AddRepository();
            services.AddAutoMappins();

        }
    }
}
