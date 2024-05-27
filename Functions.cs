using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using ApiPeliculasAWS.Repositories;
using ApiPeliculasAWS.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApiPeliculasAWS;

public class Functions
{
    private RepositoryPelis repo;

    public Functions(RepositoryPelis repo)
    {
        this.repo = repo;
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/GetAllPeliculas")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        List<Peli> pelis = await this.repo.GetPelisAsync();
        return HttpResults.Ok(pelis);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/GetPeliculasActores")]
    public async Task<IHttpResult> Find([FromQuery] string actor, ILambdaContext context)
    {
        context.Logger.LogInformation($"Handling the 'Get' Request");
        List<Peli> pelis = await this.repo.GetPeliculasActores(actor);
        return HttpResults.Ok(pelis);
    }
}
