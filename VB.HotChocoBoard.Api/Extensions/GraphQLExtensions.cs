using System.Reflection;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Http.Features;
using VB.BookStore.Api.GraphQL.Mappings;
using VB.BookStore.Api.GraphQL.Middlewares;
using VB.BookStore.Api.GraphQL.Mutations;
using VB.BookStore.Api.GraphQL.Queries;
using VB.HotChocoBoard.Infrastructure.Data;

namespace VB.BookStore.Api.Extensions;

public static class GraphQlExtensions
{
    public static IServiceCollection ConfigureGraphQl(this IServiceCollection services)
    {
        services.Configure<FormOptions>(opt =>
        {
            opt.MultipartBodyLengthLimit = 268435456;
        });
        
        services
            .AddGraphQL()
            .DisableIntrospection(false)
            .ModifyRequestOptions(opt =>
            {
                opt.EnableSchemaFileSupport = true;
                opt.IncludeExceptionDetails = true;
            })
            .AddAuthorizationCore()
            .RegisterDbContextFactory<BoardDbContext>()
            .AddObjectTypeMappings()
            .AddMutationTypes()
            .AddQueryTypes()
            .AddProjections()
            .AddFiltering()
            .AddSorting()
            .UseField<ResultTranslationMiddleware>()
            .ModifyCostOptions(options =>
            {
                options.MaxTypeCost = 20_500;
                options.MaxFieldCost = 20_500;
            });

        return services;
    }

    public static WebApplication UseGraphQlConfiguration(this WebApplication app)
    {
        var graphQlEndpointConventionBuilder = app
            .MapGraphQL();

        if (app.Environment.IsProduction())
            graphQlEndpointConventionBuilder.RequireAuthorization();
        

        return app;
    }
    
    static IRequestExecutorBuilder AddObjectTypeMappings(this IRequestExecutorBuilder builder)
    {
        var assembly = typeof(ITypeMapper).Assembly;
        
        var mappers = assembly
            .GetTypes()
            .Where(ty => typeof(ITypeMapper).IsAssignableFrom(ty) 
                         && ty is { IsInterface: false, IsAbstract: false });

        foreach (var mapper in mappers)
            builder.AddType(mapper);

        return builder;
    }

    static IRequestExecutorBuilder AddQueryTypes(this IRequestExecutorBuilder builder)
    {
        var queryType = typeof(Query);
        var queryExtensions = queryType.Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(queryType));

        builder
            .AddQueryType(d => d.Name(queryType.Name))
            .ModifyRequestOptions(opt =>
            {
                opt.EnableSchemaFileSupport = true;
                opt.IncludeExceptionDetails = true;
            });

        foreach (var queryExtension in queryExtensions)
            builder.AddObjectTypeExtension(queryExtension, queryType.Name);
        

        return builder;
    }
    
    static IRequestExecutorBuilder AddMutationTypes(this IRequestExecutorBuilder builder)
    {
        var mutationType = typeof(Mutation);
        var mutationExtensions = mutationType.Assembly
            .GetTypes()
            .Where(t => t.IsSubclassOf(mutationType));

        builder
            .AddMutationType(d => d.Name(mutationType.Name))
            .ModifyRequestOptions(opt =>
            {
                opt.EnableSchemaFileSupport = true;
                opt.IncludeExceptionDetails = true;
            });

        foreach (var mutationExtension in mutationExtensions)
            builder.AddObjectTypeExtension(mutationExtension, mutationType.Name);
        

        return builder;
    }

    static IRequestExecutorBuilder AddObjectTypeExtension(
        this IRequestExecutorBuilder builder,
        Type type,
        string name)
    {
        var method = typeof(GraphQlExtensions)
            .GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
            .First(method => method is { Name: nameof(AddObjectTypeExtension), IsGenericMethod: true });

        return (IRequestExecutorBuilder)method
            .MakeGenericMethod(type)
            .Invoke(null, [builder, name])!;
    }
    
    static IRequestExecutorBuilder AddObjectTypeExtension<T>(this IRequestExecutorBuilder builder, string name)
        => builder.AddObjectTypeExtension<T>(d => d.Name(name));
}