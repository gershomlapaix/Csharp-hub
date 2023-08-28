using Learning.Data;
using Microsoft.EntityFrameworkCore;

namespace Learning{
    public class Startup{
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration{get;}

        // register services that will start on the project launch
        public void ConfigureServices(IServiceCollection services){
            services.AddDbContext<LearningContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LearningDB")));

            // adding database exception filter
            services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}