using CavaleiroDosSetReinos.Models;
using CavaleiroDosSetReinos.UI;
using CavaleiroDosSetReinos.Story;

namespace CavaleiroDosSetReinos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Cavaleiro dos Sete Reinos";

            Display.TelaAbertura();

            //Criação do personagem
            Console.ForegroundColor = ConsoleColor.White;
            Display.EscreverLinha("\n  Qual é o nome do seu cavaleiro?\n");
            Console.Write("  > ");
            string nomeBase   = Console.ReadLine()?.Trim() ?? "Desconhecido";
            if (string.IsNullOrWhiteSpace(nomeBase)) nomeBase = "Desconhecido";
            Console.ResetColor();

            Jogador jogador = new Jogador("Sir " + nomeBase);

            Historia.Prologo(jogador);

            if (!Historia.Capitulo1(jogador, nomeBase))
            {
                Display.TelaGameOver(jogador);
                return;
            }

            if (!Historia.Capitulo2(jogador, nomeBase))
            {
                Display.TelaGameOver(jogador);
                return;
            }

            if (!Historia.Capitulo3(jogador, nomeBase))
            {
                Display.TelaGameOver(jogador);
                return;
            }

            Display.TelaVitoria(jogador);
        }
    }
}
