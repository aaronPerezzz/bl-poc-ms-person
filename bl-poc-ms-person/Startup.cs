using bl_poc_ms_person.Context;
using bl_poc_ms_person.Interface;
using bl_poc_ms_person.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace bl_poc_ms_person
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("defaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("totalRegistros")
                    .WithExposedHeaders("totalPaginas");
                });
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "bl-poc-persons", 
                    Version = "v1",
                    Description = "Api encargada de administrar información de una persona"
                });
               
            });

            services.AddScoped<IPerson, PersonService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
