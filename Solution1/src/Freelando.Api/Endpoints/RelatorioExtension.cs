using Freelando.Api.Responses;
using Freelando.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freelando.Api.Endpoints;

public static class RelatorioExtension
{
    public static void AddEndpointRelatorios(this WebApplication app)
    {
        app.MapGet("/relatorios/precoContrato/{valor}", async ([FromServices] FreelandoContext contexto, decimal valor) =>
        {
            var consulta = contexto.Contratos.FromSql($"SELECT * FROM dbo.TB_Contratos WHERE Valor > {valor}").ToList();
            return consulta;
        }).WithTags("Relatorios").WithOpenApi();

        app.MapGet("/relatorios/nomeCliente/{nomeCliente}", async ([FromServices] FreelandoContext contexto, string nomeCliente) =>
        {
            var consulta = contexto.Database
            .SqlQueryRaw<ClienteProjetoResponse>(@$"SELECT C.ID_Cliente, C.Nome, C.Email, P.ID_Projeto, P.Titulo, P.DS_Projeto, P.Status
                FROM dbo.TB_Clientes C INNER JOIN dbo.TB_Projetos P ON C.ID_Cliente = P.ID_Cliente
                WHERE C.Nome LIKE '%{nomeCliente}%'")
            .ToList();
            return consulta;
        }).WithTags("Relatorios").WithOpenApi();
    }
}
