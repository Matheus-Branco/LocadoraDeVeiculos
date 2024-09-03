using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Reflection;
using LocadoraDeVeiculos.Aplicacao.ModuloAutenticacao;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCombustivel;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloCombustivel;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;

namespace LocadoraDeVeiculos.WebApp
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDbContext>();

			builder.Services.AddScoped<IRepositorioGrupoVeiculos, RepositorioGrupoVeiculosEmOrm>();
			builder.Services.AddScoped<IRepositorioVeiculo, RepositorioVeiculoEmOrm>();
            builder.Services.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaEmOrm>();
            builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxaEmOrm>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
            builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutorEmOrm>();
            builder.Services.AddScoped<IRepositorioConfiguracaoCombustivel, RepositorioConfiguracaoCombustivelEmOrm>();
            builder.Services.AddScoped<IRepositorioConfiguracaoCombustivel, RepositorioConfiguracaoCombustivelEmOrm>();

            builder.Services.AddScoped<ServicoGrupoVeiculos>();
			builder.Services.AddScoped<ServicoVeiculo>();
            builder.Services.AddScoped<ServicoPlanoCobranca>();
            builder.Services.AddScoped<ServicoTaxa>();
            builder.Services.AddScoped<ServicoCliente>();
            builder.Services.AddScoped<ServicoCondutor>();
            builder.Services.AddScoped<ServicoCombustivel>();
            builder.Services.AddScoped<ServicoLocacao>();

            builder.Services.AddScoped<FotoValueResolver>();
			builder.Services.AddScoped<GrupoVeiculosResolver>();
			builder.Services.AddScoped<TaxasSelecionadasValueResolver>();

            builder.Services.AddScoped<TaxasValueResolver>();
            builder.Services.AddScoped<CondutoresValueResolver>();
            builder.Services.AddScoped<VeiculosValueResolver>();
            builder.Services.AddScoped<ValorParcialValueResolver>();
            builder.Services.AddScoped<ValorTotalValueResolver>();

            builder.Services.AddScoped<ServicoAutenticacao>();

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
