// See https://aka.ms/new-console-template for more information
using Marten;
using Status;

//Console.WriteLine("This is a .NET Application");
//Console.WriteLine("Another line");

//var statusId = Guid.NewGuid().ToString();
//var statusMessage = "Looks good. Just learning some .net";
//var statusTime = DateTimeOffset.Now;
//Console.WriteLine($"The id {statusId} status: {statusMessage} at {statusTime}");

//var statusMessage = new StatusMessage(Guid.NewGuid(), "Looks good", DateTimeOffset.Now);
//Console.WriteLine($"The id {statusMessage.Id} status: {statusMessage.Message} at {statusMessage.When}");

var builder = WebApplication.CreateBuilder(args);

// configure "services" - Entities, Values, Services
var connectionString = "host=localhost;database=status_dev;username=postgres;password=TokyoJoe138!;port=5432";
builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;
});

var app = builder.Build();

app.MapGet("/status", () =>
{
    var statusMessage = new StatusMessage(Guid.NewGuid(), "Looks Good", DateTimeOffset.Now);
    return Results.Ok(statusMessage);
});

app.MapPost("/status", async (StatusChangeRequest request, IDocumentSession db) =>
{
    // save message in database
    var messageToSave = new StatusMessage(Guid.NewGuid(), request.Message, DateTimeOffset.Now);
    db.Store<StatusMessage>(messageToSave);
    await db.SaveChangesAsync(); 
    return Results.Ok(messageToSave);
});

app.Run(); // "Block"