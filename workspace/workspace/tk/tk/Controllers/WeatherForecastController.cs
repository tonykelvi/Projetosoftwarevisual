using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace tk.Controllers
{

    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public Pessoa Post(Pessoa usuario)
        {

            usuario.nasc.AddYears(1);
            return usuario;                  
        }
        /*[HttpGet]
        public Pessoa Get()
        {
            Pessoa p = new Pessoa();
            p.nome = "Jango";
            //p.nasc = DateTime.Now; // Retorna o dia atual
            p.nasc = new DateTime(2000, 10, 22); // Inserindo a data de nascimento
            return p;            
        }
        */
    }
}
