using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Server {
	public class Startup {
		public void ConfigureServices(IServiceCollection services) {
			services.AddSignalR();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if ( env.IsDevelopment() ) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseStaticFiles();

			app.UseEndpoints(endpoints => {
				endpoints.MapHub<ChatHub>("/chat");
			});
		}
	}
}