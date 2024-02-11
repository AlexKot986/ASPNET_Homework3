using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using StorageFacility.Abstractions;
using StorageFacility.Contexts;
using StorageFacility.Mappers;
using StorageFacility.Services;
using WebApplication1.GraphQl;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<StorageFacilityContext>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSingleton<IProductService, ProductService>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


var app = builder.Build();



app.MapGraphQL();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
