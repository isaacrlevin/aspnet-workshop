using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace BackEnd;

public static class SpeakerEndpoints
{
    public static void MapSpeakerEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Speaker").WithTags(nameof(Speaker));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Speakers.ToListAsync();
        })
        .WithTags("Speaker").WithName("GetAllSpeakers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Speaker>, NotFound>> (int id, ApplicationDbContext db) =>
        {
            return await db.Speakers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Speaker model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithTags("Speaker").WithName("GetSpeakerById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Speaker speaker, ApplicationDbContext db) =>
        {
            var affected = await db.Speakers
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, speaker.Id)
                    .SetProperty(m => m.Name, speaker.Name)
                    .SetProperty(m => m.Bio, speaker.Bio)
                    .SetProperty(m => m.WebSite, speaker.WebSite)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithTags("Speaker").WithName("UpdateSpeaker")
        .WithOpenApi();

        group.MapPost("/", async (Speaker speaker, ApplicationDbContext db) =>
        {
            db.Speakers.Add(speaker);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Speaker/{speaker.Id}",speaker);
        })
        .WithTags("Speaker").WithName("CreateSpeaker")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApplicationDbContext db) =>
        {
            var affected = await db.Speakers
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithTags("Speaker").WithName("DeleteSpeaker")
        .WithOpenApi();
    }
}
