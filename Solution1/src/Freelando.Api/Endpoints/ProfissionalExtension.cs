using Freelando.Api.Converters;
using Freelando.Api.Requests;
using Freelando.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freelando.Api.Endpoints;

public static class ProfissionalExtension
{
    public static void AddEndPointProfissional(this WebApplication app)
    {
        app.MapGet("/profissionais", async ([FromServices] ProfissionalConverter converter, [FromServices] FreelandoContext contexto) =>
        {
            var profissional = converter.EntityListToResponseList(contexto.Profissionais.Include(e => e.Especialidades).ToList());
            var entries = contexto.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(profissional));
        }).WithTags("Profissional").WithOpenApi();

        app.MapPost("/profissional", async ([FromServices] ProfissionalConverter converter, [FromServices] FreelandoContext contexto, ProfissionalRequest profissionalRequest) =>
        {
            var profissional = converter.RequestToEntity(profissionalRequest);
            await contexto.Profissionais.AddAsync(profissional);
            await contexto.SaveChangesAsync();
            return Results.Created($"/profissional/{profissional.Id}", profissional);
        }).WithTags("Profissional").WithOpenApi();

        app.MapPut("/profissional/{id}", async ([FromServices] ProfissionalConverter converter, [FromServices] FreelandoContext contexto, Guid id, ProfissionalRequest profissionalRequest) =>
        {
            var profissional = await contexto.Profissionais.FindAsync(id);
            if (profissional is null) return Results.NotFound();

            var profissionalUpdated = converter.RequestToEntity(profissionalRequest);
            profissional.Nome = profissionalUpdated.Nome;
            profissional.Cpf = profissionalUpdated.Cpf;
            profissional.Email = profissionalUpdated.Email;
            profissional.Telefone = profissionalUpdated.Telefone;

            await contexto.SaveChangesAsync();
            return Results.Ok(profissional);
        }).WithTags("Profissional").WithOpenApi();

        app.MapDelete("/profissional/{id}", async ([FromServices] EspecialidadeConverter converter, [FromServices] FreelandoContext contexto, Guid id) =>
        {
            var profissional = await contexto.Profissionais.FindAsync(id);
            if (profissional is null) return Results.NotFound();

            contexto.Profissionais.Remove(profissional);
            await contexto.SaveChangesAsync();

            return Results.NoContent();
        }).WithTags("Profissional").WithOpenApi();
    }
}