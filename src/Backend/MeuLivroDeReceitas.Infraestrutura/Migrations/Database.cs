using Dapper;
using MySqlConnector;
using System;

namespace MeuLivroDeReceitas.Infraestrutura.Migrations;

public static class Database
{
    public static void CriarDatabase(string conexaoComBancoDeDados, string nomeDatabase ) 
    {
        using var minhaConexao =  new MySqlConnection(conexaoComBancoDeDados);

        var parametros = new DynamicParameters();
        parametros.Add("nome", nomeDatabase);

        /*Verificar se existe dataBase*/

        var registros = minhaConexao.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @nome", parametros);

        if(!registros.Any())
        {
            /*string interpolation Exemplo: ($"CREATE DATABASE {nomeDatabase}")*/
            minhaConexao.Execute($"CREATE DATABASE {nomeDatabase}");
        }

    }
}
