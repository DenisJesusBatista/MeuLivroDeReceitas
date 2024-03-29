using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Infraestrutura;
using MeuLivroDeReceitas.Infraestrutura.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositorio(builder.Configuration);
//builder.Services.AddRepositorioPostgres(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AtualizarBaseDeDados(); 

app.Run();

void AtualizarBaseDeDados()
{
    var conexao = builder.Configuration.GetConexao();
    var nomeDatabase = builder.Configuration.GetNomeDataBase();

    Database.CriarDatabase(conexao, nomeDatabase);
    //Database.GetMatchCode(conexao, nomeDatabase);

    app.MigrateBancoDados();
}
