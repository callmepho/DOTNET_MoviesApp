using FrontendMovieApp.Clients;
using FrontendMovieApp.Components;

var builder = WebApplication.CreateBuilder(args); // Create a new instance of WebApplication Class

// Add services to the container.
// Services are objects that are used to add functionality to the application
// Such as NavigationMananger, HttpClient, etc.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
// RazorComponents are a new feature in ASP.NET Core that allows you to build web applications using C# and HTML

var movieAppUrl = builder.Configuration["movieApiUrl"] ?? throw new Exception("Movie API URL is not set"); // get the URL of the movie app from the configuration file


// add the HttpClient service to the container
builder.Services.AddHttpClient<MoviesClient>(client => client.BaseAddress = new Uri(movieAppUrl));
builder.Services.AddHttpClient<GenresClient>(client => client.BaseAddress = new Uri(movieAppUrl));

var app = builder.Build(); // Build the application // creates an instance of the WebApplication Class

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // redirects HTTP requests to HTTPS

app.UseStaticFiles(); // serves static files such as images, CSS, and Javascript in the wwwroot folder
app.UseAntiforgery(); // protects the application from cross-site request forgery (CSRF) attacks

app.MapRazorComponents<App>().AddInteractiveServerRenderMode(); // maps the RazorComponents to the App component

app.Run(); // start the application
