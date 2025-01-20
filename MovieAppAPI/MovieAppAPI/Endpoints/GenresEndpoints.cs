using Microsoft.EntityFrameworkCore;
using MovieAppAPI.Data;
using MovieAppAPI.Entities;

namespace MovieAppAPI.Endpoints
{
    public static class GenresEndpoints
    {   
        public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");


            //GET all genres
            group.MapGet("/", async (MovieContext movieContext) => await movieContext.Genres.ToListAsync());

            //GET genre by id
            group.MapGet("/{id}", async (MovieContext movieContext, int id) =>
            {

                Genre? genre = await movieContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

                return genre is null ? Results.NotFound() : Results.Ok(genre);

            });

            //POST create genre

            group.MapPost("/", async (Genre newGenre, MovieContext movieContext) =>
            {
                movieContext.Genres.Add(newGenre);
                await movieContext.SaveChangesAsync();
                return Results.Created($"/movies/{newGenre.Id}", newGenre);
            });

            //DELETE
            group.MapDelete("/{id}", async (int id, MovieContext movieContext) =>
            {
                Genre? genre = await movieContext.Genres.FindAsync(id);
                if (genre is null)
                {
                    return Results.NotFound();
                }

                movieContext.Genres.Remove(genre);
                await movieContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
