using Microsoft.AspNetCore.Mvc;

namespace Sub.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaController : ControllerBase
{
    [HttpPost]
    public Pessoa Post(Pessoa usuario)
    {
    	//TAREFA 1: determinar o signo da pessoa com base no atributo "nascimento" e colocar ele no campo "signo"
        
        var n = usuario.nascimento;
        
        if(n != null)
        {
		    if(n > new DateTime(n.Value.Year, 12, 21))
		    {
		    	usuario.signo = "Capricorn";
		    }
		    else if(n > new DateTime(n.Value.Year, 11, 21))
		    {
		    	usuario.signo = "Sagittarius";
		    }
		    else if(n > new DateTime(n.Value.Year, 10, 22))
		    {
		    	usuario.signo = "Scorpio";
		    }
		    else if(n > new DateTime(n.Value.Year, 9, 22))
		    {
		    	usuario.signo = "Libra";
		    }
		    else if(n > new DateTime(n.Value.Year, 8, 22))
		    {
		    	usuario.signo = "Virgo";
		    }
		    else if(n > new DateTime(n.Value.Year, 7, 22))
		    {
		    	usuario.signo = "Leo";
		    }
		    else if(n > new DateTime(n.Value.Year, 6, 20))
		    {
		    	usuario.signo = "Cancer";
		    }
		    else if(n > new DateTime(n.Value.Year, 5, 20))
		    {
		    	usuario.signo = "Gemini";
		    }
		    else if(n > new DateTime(n.Value.Year, 4, 20))
		    {
		    	usuario.signo = "Taurus";
		    }
		    else if(n > new DateTime(n.Value.Year, 3, 20))
		    {
		    	usuario.signo = "Aries";
		    }
		    else if(n > new DateTime(n.Value.Year, 2, 19))
		    {
		    	usuario.signo = "Pisces";
		    }
		    else if(n > new DateTime(n.Value.Year, 1, 21))
		    {
		    	usuario.signo = "Aquarius";
		    }
		    else
		    {
		    	usuario.signo = "Capricorn";
		    }
		    
		    //TAREFA 2: preencha o atributo "contrario" com o nome da pessoa escrito ao contrario, em letras maiusculas, e com cada letra separada por um espaco
        	
        	//TODO
        	
        	return usuario;
		}
		
        return usuario;
    }
}
