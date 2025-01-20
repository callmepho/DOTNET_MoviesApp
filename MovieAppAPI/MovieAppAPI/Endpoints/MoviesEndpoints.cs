using Microsoft.EntityFrameworkCore;
using MovieAppAPI.Data;
using MovieAppAPI.Entities;

namespace MovieAppAPI.Endpoints
{
    public static class MoviesEndpoints
    {
        public static RouteGroupBuilder MapMoviesEnpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies");
            
            //GET All 
            group.MapGet("/", async (MovieContext movieContext) => await movieContext.Movies.Include("Genre").ToListAsync());

            //GET by id
            group.MapGet("/{id}", async (MovieContext movieContext, int id) =>
            {

                Movie? movie = await movieContext.Movies.Include("Genre").FirstOrDefaultAsync(x => x.Id == id);

                return movie is null ? Results.NotFound() : Results.Ok(movie);

            });

            //Post create
            group.MapPost("/", async (Movie newMovie, MovieContext movieContext) =>
            {
                newMovie.Genre = await movieContext.Genres.FirstOrDefaultAsync(x => x.Id == newMovie.GenreId);
                movieContext.Movies.Add(newMovie);
                await movieContext.SaveChangesAsync();
                return Results.Created($"/movies/{newMovie.Id}", newMovie);
            });

            //PUT edit
            group.MapPut("/{id}", async (int id, Movie updatedMovie, MovieContext movieContext) =>
            {
                Movie? movie = await movieContext.Movies.FindAsync(id);

                if (movie is null)
                {
                    return Results.NotFound();
                }


                //movieContext.Entry(movie).CurrentValues.SetValues(updatedMovie);

                if (updatedMovie.Name is not null) { movie.Name = updatedMovie.Name; }
                if (updatedMovie.GenreId != 0) { movie.GenreId = updatedMovie.GenreId; movie.Genre = movieContext.Genres.Find(updatedMovie.GenreId); }
                if (updatedMovie.Price != 0) { movie.Price = updatedMovie.Price; }
                if (updatedMovie.ReleaseDate != default) { movie.ReleaseDate = updatedMovie.ReleaseDate; }

                movieContext.Movies.Update(movie);
                await movieContext.SaveChangesAsync();
                return Results.NoContent();

            });

            //DELETE
            group.MapDelete("/{id}", async (int id, MovieContext movieContext) =>
            {
                // movies.RemoveAll(movie => movie.Id == id);
                Movie? movie = await movieContext.Movies.FindAsync(id);
                if (movie is null)
                {
                    return Results.NotFound();
                }

                movieContext.Movies.Remove(movie);
                await movieContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }
    }
}
