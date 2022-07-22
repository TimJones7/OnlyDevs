using API.DataAccess.Data;
using API.DataAccess.Schema.Mutations;
using API.DataAccess.Schema.Queries;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Register Services

//This registers the classes for GraphQL to map Queries and Mutations to
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddPooledDbContextFactory<DevDbContext>(options =>
{
    string dbConnection = builder.Configuration.GetConnectionString("default");
    options.UseSqlite(dbConnection);
});

//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<DevDbContext>()
//    .AddDefaultTokenProviders();
builder.Services.AddAuthorization();

var app = builder.Build();

//  Configure Middleware

app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();


app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    //GraphQL is our single endpoint
    endpoints.MapGraphQL();
});


using (IServiceScope scope = app.Services.CreateScope())
{
    IDbContextFactory<DevDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DevDbContext>>();

    using (DevDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.Run();
