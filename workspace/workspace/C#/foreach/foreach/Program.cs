using System;

namespace FOREACH{

    class teste {
        static void Main (){
            
            var nome = "tony";
            var x = " ";
            
            for(int i = 0; i < nome.Length; i++){

                x += nome[i] + " ";
            }
             nome = new string(x.Reverse().ToArray());
             Console.WriteLine("Nome invertido : " + nome.ToUpper());


            /*
            int[] num = new int [6] {11,22,33,44,55,66};

            string[] letras = new string [2]{"Leitura", "arroz"};


            // USANDO FOR
            // for (int i=0; i<num.Length; i++){
            //     Console.WriteLine(num[i]);
            // ATRIBUINDO TODAS AS POSIÇOES COM 0
            // num[i] = 0;
            // }

            //USANDO FOREACH 
            //OBS SÓ PARA FAZER A LEITURA, NÀO É POSSIVEL ATRIBUIR ATRAVÉS DO FOREACH
            foreach(int n in num){
                Console.WriteLine(n);
            }

            //VEJA QUE O TIPO DEVE ESTÁ IGUAL AO ESCOPO, COMO O STRING NESSE EXEMPLO.
            foreach(string l in letras)
            {
                Console.WriteLine(l);
            }

            int calculoidade(){
            var nasc = new DateTime (2000, 12, 23);
            var diaAtual = DateTime.Now;

            var idade = 0;

            idade = diaAtual.Year - nasc.Year;
            if(nasc > diaAtual.AddYears(-idade)) idade --;

            return idade;
        }


            Console.WriteLine(calculoidade()); */
        }
    }
}

/*
	RESOLUCAO DA PROVA
*/
/*
	Curitiba, 2022/1
	Universidade Positivo
	Desenvolvimento de Software Visual
	Prof Jean Diogo
	
	PROVA 1
	
	ESPECIFICACAO
	
	A Universidade Positivo esta desenvolvendo uma API em C# para controlar a alocacao de quioesques nos blocos do campus Ecoville
	As entidades do sistema sao "Quioesque", "Bloco" e "Alocacao"
	Soh existe um bloco de cada cor e soh um quiosque por empresa, portanto usaremos cor e empresa como "chaves primarias"
	Os tipos de alimento servidos pelos quiosques sao "Salgado", "Doce" ou "Bebida"
	Os horarios de funcionamento dos blocos e quiosques sao "Manha", "Noite" ou "Ambos"
	Cada bloco possui seu tipo de alimento preferido conforme pesquisa feita pela universidade
	Os blocos e quoisques foram cadastrados na funcao Main, que nao deve ser alterada
	Falta implementar quatro funcoes, dentre elas a funcao que aloca os quiosques nos blocos
	O que cada funcao faz esta escrito no comentario acima dela
	As alocacoes devem cumprir as seguintes condicoes:
	- no maximo dois quiosques por bloco
	- o quiosque deve servir o alimento preferido do bloco
	- o bloco tem que estar aberto em todo horario de funcionamento do quiosque (mas nao tem problema se o quiosque estiver fechado em parte do horario do bloco)
*/

/*
using System.Collections.Generic;

namespace Prova1
{
	class Quiosque
	{
		public string Empresa;
		public bool   ServeBebida;
		public bool   ServeSalgado;
		public bool   ServeDoce;
		public string Horario;
		
		public Quiosque(string empresa, bool serveBebida, bool serveSalgado, bool serveDoce, string horario)
		{
			Empresa      = empresa;
			ServeBebida  = serveBebida;
			ServeSalgado = serveSalgado;
			ServeDoce    = serveDoce;
			Horario      = horario;
		}
	}
	
	class Bloco
	{
		public string Cor;
		public string AlimentoPreferido;
		public string Horario;
		public int    NumeroQuiosques;
		
		public Bloco(string cor, string alimentoPreferido, string horario)
		{
			Cor               = cor;
			AlimentoPreferido = alimentoPreferido;
			Horario           = horario;
			NumeroQuiosques   = 0;
		}
	}
	
	class Alocacao
	{
		public string EmpresaQuiosque;
		public string CorBloco;
		
		public Alocacao(string empresaQuiosque, string corBloco)
		{
			EmpresaQuiosque = empresaQuiosque;
			CorBloco        = corBloco;
		}
	}
	
	class Controle
	{
		public List<Quiosque> Quiosques;
		public List<Bloco>    Blocos;
		public List<Alocacao> Alocacoes;
		
		public Controle()
		{
			Quiosques = new List<Quiosque>();
			Blocos    = new List<Bloco>();
			Alocacoes = new List<Alocacao>();
		}

        public int GetnumeroQuiosquesApenasNoite(){

            int NumeroQuiosquesApenasNoite = 0;

            foreach (var quiosque in Quiosques)
            {
                if(quiosque.Horario == "Noite")
                NumeroQuiosquesApenasNoite ++;
            }
            return NumeroQuiosquesApenasNoite;
        }
        public  string GetEmpresasSalgadoManha(){

            string empresasSalgadoManha = "";

            foreach(var quiosque in Quiosques){
                if(quiosque.ServeSalgado && (quiosque.Horario == "Manha" || quiosque.Horario == "Ambos"))
                {
                    empresasSalgadoManha += quiosque.Empresa + ", ";
                }
            }
            return empresasSalgadoManha;
        }
        public string GetAlimentoMaisPreferido(){

            string alimentoMaisPreferido = "";
            int numBebida = 0;
            int numDoce = 0;
            int numSalgado = 0;
            
            foreach (var bloco in Blocos){
                if(bloco.AlimentoPreferido == "Bebida")
                {
                    numBebida ++;
                }
                if(bloco.AlimentoPreferido == "Doce")
                {
                    numDoce ++;
                }
                if(bloco.AlimentoPreferido == "Salgado")
                {
                    numSalgado ++;
                }
            }
            if(numSalgado > numDoce && numSalgado > numBebida){
                alimentoMaisPreferido = "Salgado";
            }
            else if(numDoce > numBebida && numDoce > numSalgado){
                alimentoMaisPreferido = "Doce";
            }
            else
            {
                alimentoMaisPreferido = "Bebida";
            }

            return alimentoMaisPreferido;
        }
        public bool DeuMatch(Quiosque quiosque, Bloco bloco)
        {
            if(bloco.NumeroQuiosques >=2)
            {
                return false;
            }
            if(bloco.AlimentoPreferido == "Salgado" && !quiosque.ServeSalgado){
                return false;
            }
            if(bloco.AlimentoPreferido == "Doce" && !quiosque.ServeDoce){
                return false;
            }
            if(bloco.AlimentoPreferido == "Bebida" && !quiosque.ServeBebida)
            {
                return false;
            }
            if(bloco.Horario != "Ambos" && bloco.Horario != quiosque.Horario)
            {
                return false;
            }

            return true;
        }
        
        public void AlocarTodoMundo(){
            foreach(var quiosque in Quiosques)
            {
                foreach(var bloco in Blocos)
                {
                    if(DeuMatch(quiosque, bloco))
                    {
                        Alocacoes.Add(new Alocacao(quiosque.Empresa, bloco.Cor));
                        bloco.NumeroQuiosques ++;
                        break;
                    }
                }
            }
        }
        
	class Program
	{
		static void Main(string[] args)
		{
			var controle = new Controle();
			
			controle.Quiosques.Add(new Quiosque("Bobs"        , true , true , false, "Manha"));
			controle.Quiosques.Add(new Quiosque("Burger King" , true , true , false, "Ambos"));
			controle.Quiosques.Add(new Quiosque("Cabra Café"  , true , false, false, "Manha"));
			controle.Quiosques.Add(new Quiosque("Cacau Show"  , false, false, true , "Noite"));
			controle.Quiosques.Add(new Quiosque("Freddo"      , false, false, true , "Manha"));
			controle.Quiosques.Add(new Quiosque("Giraffas"    , true , true , false, "Manha"));
			controle.Quiosques.Add(new Quiosque("McDonalds"   , true , true , false, "Ambos"));
			controle.Quiosques.Add(new Quiosque("Pizza Hut"   , false, true , false, "Noite"));
			controle.Quiosques.Add(new Quiosque("Ultra Coffee", true , false, true , "Ambos"));
			controle.Quiosques.Add(new Quiosque("Zuka"        , false, false, true , "Noite"));
			
			controle.Blocos.Add(new Bloco("Amarelo" , "Salgado", "Ambos"));
			controle.Blocos.Add(new Bloco("Azul"    , "Doce"   , "Noite"));
			controle.Blocos.Add(new Bloco("Bege"    , "Salgado", "Noite"));
			controle.Blocos.Add(new Bloco("Branco"  , "Salgado", "Manha"));
			controle.Blocos.Add(new Bloco("Cinza"   , "Doce"   , "Ambos"));
			controle.Blocos.Add(new Bloco("Laranja" , "Salgado", "Ambos"));
			controle.Blocos.Add(new Bloco("Marrom"  , "Salgado", "Manha"));
			controle.Blocos.Add(new Bloco("Verde"   , "Bebida" , "Manha"));
			controle.Blocos.Add(new Bloco("Vermelho", "Doce"   , "Manha"));
			controle.Blocos.Add(new Bloco("Roxo"    , "Bebida" , "Noite"));
			
            controle.AlocarTodoMundo();


			Console.WriteLine(controle.GetnumeroQuiosquesApenasNoite());
            Console.WriteLine(controle.GetEmpresasSalgadoManha());
            Console.WriteLine(controle.GetAlimentoMaisPreferido());


			Console.WriteLine("Lista de alocacoes:");
			foreach(var alocacao in controle.Alocacoes)
			{
				Console.WriteLine($"O quiosque {alocacao.EmpresaQuiosque} foi alocado no bloco {alocacao.CorBloco}.");
			}
		}
	}
    }
}*/