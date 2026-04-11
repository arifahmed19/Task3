using System.Numerics; // Required for BigInteger

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Path: how88nm0qf_bwmyga_com
app.MapGet("/arifahmed_bd1_gmail_com", (HttpContext context) =>
{
    string? xRaw = context.Request.Query["x"];
    string? yRaw = context.Request.Query["y"];

    // 1. Precise Validation
    // We use BigInteger.TryParse to handle massive numbers and check if they are non-negative
    if (!BigInteger.TryParse(xRaw, out BigInteger x) || x < 0 || 
        !BigInteger.TryParse(yRaw, out BigInteger y) || y < 0)
    {
        return Results.Content("NaN", "text/plain");
    }

    // 2. Logic: LCM(a, b) = (a * b) / GCD(a, b)
    if (x == 0 || y == 0) return Results.Content("0", "text/plain");

    BigInteger gcd = BigInteger.GreatestCommonDivisor(x, y);
    BigInteger lcm = BigInteger.Abs(x * y) / gcd;

    // 3. Return as a clean string (No quotes, no HTML)
    return Results.Content(lcm.ToString(), "text/plain");
});

app.Run();
