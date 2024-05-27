using Amazon.Lambda.Annotations;
using ApiPeliculasAWS.Data;
using ApiPeliculasAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPeliculasAWS;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<RepositoryPelis>();
        string connectionString = @"server=awsmysqlsejo.cvgm0yoms3v8.us-east-1.rds.amazonaws.com;port=3306;user id=adminsql;password=Admin123;database=television";
        services.AddDbContext<PelisContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}
