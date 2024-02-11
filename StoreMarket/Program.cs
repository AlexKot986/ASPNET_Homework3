using Autofac.Extensions.DependencyInjection;
using StoreMarket.Abstroctions;
using StoreMarket.Contexts;
using StoreMarket.Mappers;
using StoreMarket.Services;
using WebApplication1.GraphQl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IProductService, ProductService>()
                .AddSingleton<ICategoryService, CategoryService>()
                .AddGraphQLServer().AddQueryType<Query>()
                .AddMutationType<Mutation>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Services.AddMemoryCache(m => m.TrackStatistics = true);




var app = builder.Build();

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
