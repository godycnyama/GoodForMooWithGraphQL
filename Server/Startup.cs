using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using GoodForMoo.Server.Services;
using GoodForMoo.Server.DataAccess;
using GoodForMoo.Server.GraphQL.GraphQLMutations;
using GoodForMoo.Server.GraphQL.GraphQLQueries;

namespace GoodForMoo.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllersWithViews();
            services.AddDbContext<DataAccessContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("GoodForMoo"));
            });

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType(d => d.Name("Query"))
                    .AddType<CustomerQueries>()
                    .AddType<ProductQueries>()
                    .AddType<OrderQueries>()
                    .AddMutationType(d => d.Name("Mutation"))
                    .AddType<CustomerMutations>()
                    .AddType<ProductMutations>()
                    .AddType<OrderMutations>()
                    .Create(),
                new QueryExecutionOptions { ForceSerialExecution = true });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseGraphQL("/graphql");
            app.UsePlayground("/graphql");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
