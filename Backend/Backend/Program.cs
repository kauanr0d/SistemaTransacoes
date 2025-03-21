using Backend.Data;
using Backend.Repository.Implementations;
using Backend.Repository.Interface;
using Backend.Service;
using Backend.Service.Interfaces;
using Kauan.Backend.Controller.Exceptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyHeader()   
              .AllowAnyMethod();  
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlite("Data Source=banco.db"));



builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();

builder.Services.AddScoped<IConsultaTotaisService, ConsultaTotaisService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbContext.EnsureCreated(); 
}

app.UseCors("PermitirTudo");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  
app.UseMiddleware<ExceptionMiddleware>();

app.Run();