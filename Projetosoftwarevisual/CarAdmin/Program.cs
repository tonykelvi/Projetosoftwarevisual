//RODAR ESSES COMANDOS NA PRIMEIRA VEZ
//dotnet new webapi -minimal -o NomeDoProjeto
//cd NomeDoProjeto
//dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0
//dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
//dotnet tool install --global dotnet-ef
//dotnet ef migrations add InitialCreate
//RODAR ESSE COMANDO SEMPRE QUE MEXER NAS CLASSES RELATIVAS A BASE DE DADOS
//dotnet ef database update

using System;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Trabalho
{
    [Keyless]
	class Cliente
    {
    	public int idCliente { get; set; }
		public string? nome { get; set; }
		public int contato { get; set; }
    	public string? email { get; set; }        
    }
    [Keyless]
	class Carro
    {
		public int idCarro { get; set; }
        public string? modelo { get; set; }
		public string? placa { get; set; }
    }
    [Keyless]
	class Vendedor
	{
		public int idVendedor { get; set; }
		public string? nomeFuncionario { get; set; }	
    }
    [Keyless]
	class Emprestimo
	{
        public int id { get; set; }
		public int idCliente { get; set; }
		public int idCarro { get; set; }
		public int idVendedor { get; set; }
		public string? dataempr { get; set; }
        public string? datadev { get; set; }  
    }
		
	class BaseRentCar : DbContext
	{
		public BaseRentCar(DbContextOptions options) : base(options)
		{
		}
		
		public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Carro> Carro { get; set; } = null!;
        public DbSet<Vendedor> Vendedor { get; set; } = null!;
        public DbSet<Emprestimo> Emprestimo { get; set; } = null!;
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			var connectionString = builder.Configuration.GetConnectionString("BaseRentCar") ?? "Data Source=BaseRentCar.db";
			builder.Services.AddSqlite<BaseRentCar>(connectionString);
			
			var app = builder.Build();
			
			//LISTAR
			app.MapGet("/listar/Clientes", (BaseRentCar BaseRentCar) => {
				return BaseRentCar.Clientes.ToList();
			});
			
			app.MapGet("/listar/Clientes/{id}", (BaseRentCar BaseRentCar, int id) => {
				return BaseRentCar.Clientes.Find(id);
			});
			app.MapGet("/listar/carros", (BaseRentCar BaseRentCar) => {
				return BaseRentCar.Carro.ToList();
			});
			
			app.MapGet("/listar/carros/{id}", (BaseRentCar BaseRentCar, int id) => {
				return BaseRentCar.Carro.Find(id);
			});
			app.MapGet("/listar/vendedor", (BaseRentCar BaseRentCar) => {
				return BaseRentCar.Vendedor.ToList();
			});
			
			app.MapGet("/listar/vendedor/{id}", (BaseRentCar BaseRentCar, int id) => {
				return BaseRentCar.Vendedor.Find(id);
			});


			//CADASTRAR
			app.MapPost("/cadastrar/cliente", (BaseRentCar BaseRentCar, Cliente Cliente) =>
			{
				BaseRentCar.Clientes.Add(Cliente);
				BaseRentCar.SaveChanges();
				return "Novo cliente adicionado com sucesso";
			});

			app.MapPost("/cadastrar/carro", (BaseRentCar BaseRentCar, Carro Carro) =>
			{
				BaseRentCar.Carro.Add(Carro);
				BaseRentCar.SaveChanges();
				return "Novo Carro adicionado com sucesso";
			});
			app.MapPost("/cadastrar/vendedor", (BaseRentCar BaseRentCar, Vendedor Vendedor) =>
			{
				BaseRentCar.Vendedor.Add(Vendedor);
				BaseRentCar.SaveChanges();
				return "Novo Vendedor adicionado com sucesso";
			});

			
			//ATUALIZAR 
			app.MapPost("/atualizar/cliente/{id}", (BaseRentCar BaseRentCar, Cliente ClienteAtualizado, int id) =>
			{
				var Cliente = BaseRentCar.Clientes.Find(id);
				Cliente.nome = ClienteAtualizado.nome;
				Cliente.email = ClienteAtualizado.email;
                Cliente.contato = ClienteAtualizado.contato;
				BaseRentCar.SaveChanges();
				return "Cliente atualizado com sucesso";
			});
			app.MapPost("/atualizar/carro/{id}", (BaseRentCar BaseRentCar, Carro CarroAtualizado, int id) =>
			{
				var Carro = BaseRentCar.Carro.Find(id);
				Carro.modelo = CarroAtualizado.modelo;
				Carro.placa = CarroAtualizado.placa;
				BaseRentCar.SaveChanges();
				return "Carro atualizado com sucesso";
			});
			app.MapPost("/atualizar/vendedor/{id}", (BaseRentCar BaseRentCar, Vendedor VendedorAtualizado, int id) =>
			{
				var Vendedor = BaseRentCar.Vendedor.Find(id);
				Vendedor.nomeFuncionario = VendedorAtualizado.nomeFuncionario;
				BaseRentCar.SaveChanges();
				return "Vendedor atualizado com sucesso";
			});


			//DELETAR
			app.MapPost("/deletar/cliente/{id}", (BaseRentCar BaseRentCar, int id) =>
			{
				var Cliente = BaseRentCar.Clientes.Find(id);
				BaseRentCar.Remove(Cliente);
				BaseRentCar.SaveChanges();
				return "Cliente excluido com sucesso";
			});
			app.MapPost("/deletar/carro{id}", (BaseRentCar BaseRentCar, int id) =>
			{
				var Carro = BaseRentCar.Carro.Find(id);
				BaseRentCar.Remove(Carro);
				BaseRentCar.SaveChanges();
				return "Carro excluido com sucesso";
			});
			app.MapPost("/deletar/vendedor{id}", (BaseRentCar BaseRentCar, int id) =>
			{
				var Vendedor = BaseRentCar.Vendedor.Find(id);
				BaseRentCar.Remove(Vendedor);
				BaseRentCar.SaveChanges();
				return "Vendedor excluido com sucesso";
			});						
			app.Run();
		}
	}
}