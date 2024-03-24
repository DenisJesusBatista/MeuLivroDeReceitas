using Microsoft.Extensions.Configuration;

namespace MeuLivroDeReceitas.Domain.Extension;
public static class RepositorioExtension
{
    public static string GetNomeDataBase(this IConfiguration configurationManager)
    {
        var nomeDatabase = configurationManager.GetConnectionString("NomeDatabase");

        return nomeDatabase;
       
    }

    public static string GetConnectionString(this IConfiguration configurationManager)
    {
        var conexao = configurationManager.GetConnectionString("Conexao");

        return conexao;

    }



}
