var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/isdevtunnel", (HttpContext context) =>
{
    var host = context.Request.Host.ToString();
    var forwardedHost = context.Request.Headers["X-Forwarded-Host"].ToString();
    bool isDevTunnel = forwardedHost.Contains("devtunnels.ms");

    return Results.Ok(new
    {
        Host = host,
        ForwardedHost = string.IsNullOrEmpty(forwardedHost) ? "Not provided" : forwardedHost,
        IsDevTunnel = isDevTunnel
    });
});

app.Run();