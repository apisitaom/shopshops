using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using shop_shop.Models;
using shop_shop.Services;

namespace shop_shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // requires using Microsoft.Extensions.Options
            services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

            services.Configure<AddresstoreDatabaseSettings>(
                Configuration.GetSection(nameof(AddresstoreDatabaseSettings)));

            services.AddSingleton<IAddressstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AddresstoreDatabaseSettings>>().Value);

            services.AddSingleton<BookService>();
            services.AddSingleton<AddressService>();
            services.AddSingleton<OptionService>();
            services.AddSingleton<PaymentService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<RecriveService>();
            services.AddSingleton<SellerService>();
            services.AddSingleton<ShippingService>();
            services.AddSingleton<UserService>();

            services.AddControllers()
                        .AddNewtonsoftJson(options => options.UseMemberCasing());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
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
