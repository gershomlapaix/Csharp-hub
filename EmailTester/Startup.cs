
using EmailTester.Services;

namespace EmailTester{
    public class Startup{

        // constructor
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        // properties
        public IConfiguration Configuration{get;}

        // A method load the data from appsettings.Development.json to the MailSettings at runtime
        // dependency injection and IOptions is used to do so
        public void ConfigureServices(IServiceCollection services){
           try
            {
                services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));  // attach the data to the MailSettings class
                services.AddTransient<IMailService, MailService>();
                services.AddControllers();
            }
           catch (Exception ex)
           {
            Console.WriteLine(ex);
           }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}