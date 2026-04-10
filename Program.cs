
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;// 1. This sets up the web server builder


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 2. A helper function to calculate the GCD
long GetGcd(long a, long b)
{
    while (b != 0)
    {
        long temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

// 3. Define the Web Method (The "Route")
// IMPORTANT: Replace 'how88nm0qf_bwmyga_com' with your actual formatted email
app.MapGet("/arifahmed.bd1@gmail.com", (HttpContext context) =>
{
    // 4. Extract 'x' and 'y' from the URL query string
    string xInput = context.Request.Query["x"];
    string yInput = context.Request.Query["y"];

    // 5. Validation: Is it a valid non-negative integer?
    bool isXValid = long.TryParse(xInput, out long x) && x >= 0;
    bool isYValid = long.TryParse(yInput, out long y) && y >= 0;

    if (!isXValid || !isYValid)
    {
        // Return "NaN" as a plain string if validation fails
        return Results.Content("NaN", "text/plain");
    }

    // 6. Edge case: if either is 0, the LCM is 0
    if (x == 0 || y == 0) return Results.Content("0", "text/plain");

    // 7. Calculate LCM
    long gcd = GetGcd(x, y);
    long lcm = (x * y) / gcd;

    // 8. Return the result as a plain string
    return Results.Content(lcm.ToString(), "text/plain");
});

// 9. Start the server
app.Run();

// 🚀 Step 4: Testing Locally
// To see if your code works:

// In your terminal, inside the project folder, type: dotnet run

// The terminal will show a URL, usually http://localhost:5000 or http://localhost:5123.

// Open your browser and go to:
// http://localhost:5000/how88nm0qf_bwmyga_com?x=12&y=18

// You should see 36 on a plain white screen.

// Try ?x=-5&y=10. You should see NaN.