using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Contracts;
using TrilhaApiDesafio.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrganizadorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "trilha-dotNet-api-desafio",
        Description = "Abordagem utilizada segue o padrão proposto pelo desafio e não as melhores práticas.\n" +
                      " A escolha do desenvolvedor nesse caso seria o uso de algo como o padrão CQRS para os endpoints\n" +
                      " porém com a possibilidade de o código ser corrigido por alguma ferramenta automatizada e a possibilidade\n" +
                      " de esta não estar parametrizada para o padrão CQRS impõem a decisão de seguir o padrão do desafio."
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
