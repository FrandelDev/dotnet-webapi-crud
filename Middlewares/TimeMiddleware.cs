namespace webapi.middlewares;
class TimeMiddleware{
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest){
        next = nextRequest;
    }

    public async Task Invoke(HttpContext context){
        await next(context);
        if(context.Request.Query.Any(prop => prop.Key == "time")){
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }
}

public static class TimeMiddlewareExtension{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<TimeMiddleware>();
    }
}