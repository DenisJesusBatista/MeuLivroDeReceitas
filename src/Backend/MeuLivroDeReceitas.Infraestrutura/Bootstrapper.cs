using FluentMigrator.Runner;
using MeuLivroDeReceitas.Domain.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuLivroDeReceitas.Infraestrutura;
public static class Bootstrapper
{
    public static void AddRepositorio(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigrator(services, configurationManager);

    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {       
        services.AddFluentMigratorCore().ConfigureRunner(c =>
        c.AddMySql5()
        .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("MeuLivroDeReceitas.Infraestrutura")).For.All());
    }



    public static void AddRepositorioPostgres(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigratorPostgres(services, configurationManager);

    }

    private static void AddFluentMigratorPostgres(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c =>
        c.AddPostgres()
        .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("MeuLivroDeReceitas.Infraestrutura")).For.All());
    }
}
