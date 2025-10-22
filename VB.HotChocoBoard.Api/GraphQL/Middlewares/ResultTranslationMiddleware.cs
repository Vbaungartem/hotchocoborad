using FluentValidation;
using HotChocolate.Resolvers;
using VB.HotChocoBoard.Domain.Abstraction;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.BookStore.Api.GraphQL.Middlewares;

public class ResultTranslationMiddleware(FieldDelegate next)
{
    public async Task InvokeAsync(IMiddlewareContext context)
    {
        await next(context);
        
        if (context.Result is ICustomResult result)
        {
            if (result.IsFailure)
            {
                context.ReportError(ErrorBuilder.New()
                    .SetMessage(result.Error!.Message)
                    .SetCode(result.Error.Code)
                    .Build());
                
                context.Result = null;
            }
            else
                context.Result = result.UntypedData;
        }
    }
}