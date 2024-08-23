using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Reflection;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;

namespace LocadoraDeVeiculos.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDbContext>();

			builder.Services.AddScoped<IRepositorioGrupoVeiculos, RepositorioGrupoVeiculosEmOrm>();
			builder.Services.AddScoped<ServicoGrupoVeiculos>();

			builder.Services.AddScoped<IRepositorioVeiculo, RepositorioVeiculoEmOrm>();
			builder.Services.AddScoped<ServicoVeiculo>();

			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddMaps(Assembly.GetExecutingAssembly());
			});

			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
