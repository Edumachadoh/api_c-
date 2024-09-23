using API.Models;
using Microsoft.AspNetCore.Mvc;

// Testar as APIs
// - rest Client - Extensão do VS Code
// - Postman
// - Insomnia

// MINIMAL APIs
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// EndPoints - Funcionalidades
// Request = Configurar a URL e o método/verbo HTTP
// Response = Retornar dados (json/xml) e 
List<Produto> produtos = new List<Produto>();
// produtos.Add(new Produto() {
//     Nome = "Notebook",
//     Preco = 5000,
//     Quantidade = 54
// });
// produtos.Add(new Produto() {
//     Nome = "Radio",
//     Preco = 460,
//     Quantidade = 30
// });
// produtos.Add(new Produto() {
//     Nome = "Lamparina",
//     Preco = 90,
//     Quantidade = 120
// });

app.MapGet("/", () => "API de produtos");

// GET: /produto/listar
app.MapGet("/produto/listar" , () => {

    if (produtos.Count > 0) {
        return Results.Ok(produtos);
    } 
    
    else {return Results.NotFound();
    }
});

// GET: /produto/buscar
app.MapGet("/produto/buscar/{nome}" , (string nome) => {
    foreach (Produto produtoCadastrado in produtos) {
        if (produtoCadastrado.Nome == nome) {
            return Results.Ok(produtoCadastrado);
        }   

        
    }
    return Results.NotFound();
}); 

// POST: /produto/listar
app.MapPost("/produto/cadastrar/" , ([FromBody] Produto produto) => {

   // Adicionar objeto
   produtos.Add(produto);
    return Results.Created("", produto);


});

app.MapDelete("/produto/deletar/{nome}" , (string nome) => {
    foreach (Produto produtoCadastrado in produtos) {
        if (produtoCadastrado.Nome == nome) {
            produtos.Remove(produtoCadastrado);
            return Results.Ok();
        }   
    }
    return Results.NotFound();

});

app.Run();

// criar Endpoint para receber informações
// - Receber informações pela URL da requisição
// - Pelo informações pelo corpo da requisição
//Guardar as requisições em uma lista;


/* C# UTILIZANDO SETS E GETS
Produto produto = new Produto();
produto.Preco = 5;
Console.WriteLine("Preço: " + produto.Preco); 


/* JAVA UTILIZACAO SETS E GETS
Produto produto = new Produto();
produto.setPreco(5);
Console.WriteLine("Preço: " + produto.getPreco()); */