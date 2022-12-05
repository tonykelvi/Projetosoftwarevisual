
using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SUB{
    class Pessoa
    {
        public string? nome {get; set;}
        public DateTime nasc {get; set;}
    }
    class Database : DbContext
    {
        public Database(DbContextOptions options) : base(options) {}
        public DbSet<Pessoa> Pessoas {get; set;} = null!;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddSqlite<Database>(builder.Configuration.GetConnectionString("Database") ?? "Data Source=Database.db");
			builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
			var app = builder.Build();
			app.UseCors();

             app.MapPost("/pessoas", (Database database, Pessoa usuario) =>
			{
                database.Pessoas.Add(usuario);
                database.SaveChanges();
                return usuario;
        });
            app.Run();
        }       
    }
}