using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/dado/d{NumeroDeFaces}",( [FromRoute] int NumeroDeFaces ) => {
    if (NumeroDeFaces <= 0)
    {
        return Results.BadRequest(new { mensagem = "somente dados com pelo menos uma face"});
    }

    int face = RandomNumberGenerator.GetInt32(1,NumeroDeFaces + 1);

    return Results.Ok( new { dado = $"d{NumeroDeFaces}", rolagem = face });
});

app.Run();
