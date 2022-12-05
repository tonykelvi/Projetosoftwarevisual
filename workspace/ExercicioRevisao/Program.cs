using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Sub
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			builder.Services.AddControllers();
			
			builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
			
			var app = builder.Build();
			
			app.UseCors();
			
			app.MapControllers();

			app.Run("http://localhost:3000");
		}
	}
}
