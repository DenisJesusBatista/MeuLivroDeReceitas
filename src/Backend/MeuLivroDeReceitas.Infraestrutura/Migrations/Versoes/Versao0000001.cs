using FluentMigrator;

namespace MeuLivroDeReceitas.Infraestrutura.Migrations.Versoes;

[Migration((long)NumeroVersoes.CriarTabelaReceita,"Cria tabela usuario")]
public class Versao0000001 : Migration
{
    public override void Down()
    {
    }

    public override void Up()
    {
        var tabela = VersaoBase.InserirColunasPadrao(Create.Table("Receita"));

        tabela
            .WithColumn("Ingrediente").AsString(100).NotNullable();
        
    }
}
