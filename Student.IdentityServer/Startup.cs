using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Student.IdentityServer.DI.Model;
using Student.IdentityServer.DI.Model.Store;
using Student.IdentityServer.Pgsql;
using Student.IdentityServer.Pgsql.Store;

namespace Student.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;

            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("IdentityServerConnectionPgSql")));

            services.AddIdentity<StudentUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                .AddAspNetIdentity<StudentUser>();

            //.AddTestUsers(TestUsers.Users);

            // in-memory, code config
            //builder.AddInMemoryIdentityResources(Config.IdentityResources);
            //builder.AddInMemoryApiScopes(Config.ApiScopes);
            //builder.AddInMemoryClients(Config.Clients);


            builder.AddDeveloperSigningCredential()
                .AddConfigurationStore(option =>
                           option.ConfigureDbContext = builder => builder.UseNpgsql(Configuration.GetConnectionString("IdentityServerConnectionPgSql"), options =>
                           options.MigrationsAssembly("Student.IdentityServer.Pgsql")))
                .AddOperationalStore(option =>
                           option.ConfigureDbContext = builder => builder.UseNpgsql(Configuration.GetConnectionString("IdentityServerConnectionPgSql"), options =>
                           options.MigrationsAssembly("Student.IdentityServer.Pgsql")));


            // DI
            services.AddScoped<IStudentStore, StudentStorePgSql>();

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //        // register your IdentityServer with Google at https://console.developers.google.com
            //        // enable the Google+ API
            //        // set the redirect URI to https://localhost:5001/signin-google
            //        options.ClientId = "copy client ID from Google here";
            //        options.ClientSecret = "copy client secret from Google here";
            //    });
        }

        public void Configure(IApplicationBuilder app, AuthDbContext context)
        {
            DatabaseInitializer.Initialize(app, context);
            context.Database.Migrate();


            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}