//objetivos / Passo-a-passo

//v1
//1.Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
//2.Nosso jogo deve gerar um número secreto aleatório
//3.Nosso jogo deve Validar a tentativa do jogador e exibir uma mensagem
//4.nosso jogo deve permitir multiplas tentativas

//v2
//1. Nosso jogo deve implementar a funcionalidade de Dificuldade e Tentativas limitadas
//2. Nosso jogo deve implementar uma funcionalidade de Validação de Números Repetidos
//3. Nosso jogo deve implementar uma funcionalidade de Pontuação

using System;//biblioteca padrão do sistema com classes gnéricas
using System.Diagnostics;
using System.Security.Cryptography; // biblioteca padrão do sistema relacionada a criptografia

while(true == true)
{
    int[] numerosDigitados = new int [100];
    int contadorNumerosDigitados = 0; 
    int Pontuacao = 1000;

 Console.Clear();

Console.WriteLine("-------------------------------------");
Console.WriteLine("jogo de Adivinhação");
Console.WriteLine("-------------------------------------");
Console.WriteLine("Escolha o nivel de dificuldade:");
Console.WriteLine("-------------------------------------");
Console.WriteLine("1 - Fácil (10 tentativas)");
Console.WriteLine("2 - médio (5 tentativas) ");
Console.WriteLine("3 - Difícil (3 tentativas) ");
Console.WriteLine("-------------------------------------");

Console.Write("Digite sua escolha: ");
string? dificuldade = Console.ReadLine();

int numeroMaximo;
int tentativaMaximas;

switch (dificuldade)
 {    
    case"1":
        numeroMaximo = 20;
        tentativaMaximas = 10;
        break;  

    case "2":
          numeroMaximo = 50; 
          tentativaMaximas = 5;
         break;
   
    case"3":
         numeroMaximo = 100;
         tentativaMaximas = 3;
         break;  

     default:
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("por favor, selecione uma dificuldade válida.");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
        continue;              
 }       

int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

for (int tentativa = 1; tentativa <= tentativaMaximas; tentativa++)
{   
     //Console.Clear();  
     Console.WriteLine("-------------------------------------");
     Console.WriteLine($"Tentativa {tentativa} de {tentativaMaximas}");
     Console.WriteLine("-------------------------------------");

     Console.Write($"Digite um número entre 1 e {numeroMaximo}:");
string? chute = Console.ReadLine();

int numroDigitado = Convert.ToInt32(chute);

bool numeroRepetido = false;

for(int contadorNumeros = 0; contadorNumeros < numerosDigitados.Length; contadorNumeros++)
          {
             if (numerosDigitados[contadorNumeros] == numroDigitado)
               {
                    numeroRepetido = true;
                    break;
               }  
          }
    if (numeroRepetido == true)
    {
      Console.WriteLine("-------------------------------------");
      Console.WriteLine("você já digitou esse número, tente novamente.");
      Console.WriteLine("-------------------------------------");
      Console.WriteLine("Digite ENTER para continuar...");
      Console.ReadLine();

      tentativa--;

      continue;

    }
if(contadorNumerosDigitados < numerosDigitados.Length)
          {
               numerosDigitados[contadorNumerosDigitados] = numroDigitado;

               contadorNumerosDigitados++;
          }

numerosDigitados[contadorNumerosDigitados] = numroDigitado;

contadorNumerosDigitados++;


if(numroDigitado == numeroAleatorio)
{
     Console.WriteLine("-------------------------------------");
     Console.WriteLine("Parabéns, você acertou!");
     Console.WriteLine("-------------------------------------");

     break;
}
else if (numroDigitado > numeroAleatorio)
{
     Console.WriteLine("-------------------------------------");
     Console.WriteLine("O número digitado foi maior que o número secreto!");
     Console.WriteLine("-------------------------------------");
} 
else
{
     Console.WriteLine("-------------------------------------");
     Console.WriteLine("O número digitado  foi menor que o número secreto!");
     Console.WriteLine("-------------------------------------"); 
}

int diferencaNumerica = Math.Abs(numeroAleatorio - numroDigitado);  // 90 - 100 = -10;

     if (diferencaNumerica >= 10)
          {
             Pontuacao -= 100; 
          }
     else if (diferencaNumerica >= 5)
          {
               Pontuacao -= 50;
          } 
     else
          {
               Pontuacao -= 20;
          } 
     Console.WriteLine("Sua pontuação é:" + Pontuacao);
     Console.WriteLine("-------------------------------------"); 
     Console.ReadLine();   
     Console.WriteLine("Digite ENTER para continuar...");
     Console.ReadLine();

     if (tentativa == tentativaMaximas)
          {
              Console.WriteLine($"Você usou todas as suas tentativas! O número era {numeroAleatorio}.");
              Console.WriteLine("-------------------------------------");
              break;   
          }        
              
} 
     Console.WriteLine("Deseja continuar? (S/N): ");
     string? opcaoContinuar = Console.ReadLine(); 

     
     if (opcaoContinuar?.ToUpper() !="S")
     {
          break;
     } 
}

