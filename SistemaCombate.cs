using CavaleiroDosSetReinos.Models;
using CavaleiroDosSetReinos.UI;

namespace CavaleiroDosSetReinos.Combat
{
    public static class SistemaCombate
    {
        private static readonly Random _rng = new Random();

        // Inicia um combate por turnos.
        // Retorna:
        // true  — jogador venceu
        // false — jogador morreu
        // null  — jogador fugiu
        public static bool? Iniciar(
            Jogador    jogador,
            Personagem inimigo,
            int        xpRecompensa,
            int        ouroRecompensa,
            bool       podeFugir = true)
        {
            Console.Clear();
            Display.Separador();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Display.EscreverLinha($"\n  COMBATE INICIADO: {jogador.Nome} vs {inimigo.Nome}  \n");
            Console.ResetColor();
            Display.Separador();

            while (jogador.EstaVivo && inimigo.EstaVivo)
            {
                Display.ExibirStatusJogador(jogador);
                Display.ExibirStatusInimigo(inimigo);

                string escolha = LerEscolha(podeFugir);
                jogador.Defendendo = false;     // reseta defesa todo turno

                switch (escolha)
                {
                    case "1": TurnoAtacar(jogador, inimigo);  break;
                    case "2": TurnoDefender(jogador);          break;
                    case "3" when podeFugir:
                        bool fugiu = TurnoFugir();
                        if (fugiu)
                        {
                            Display.Pausa();
                            return null;
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Display.EscreverLinha("  Opção inválida. Você hesita por um momento.");
                        Console.ResetColor();
                        break;
                }

                if (inimigo.EstaVivo)
                    TurnoInimigo(inimigo, jogador);

                Console.WriteLine();
                Thread.Sleep(500);
            }

            return ProcessarResultado(jogador, inimigo, xpRecompensa, ouroRecompensa);
        }

        //Ações

        private static void TurnoAtacar(Personagem atacante, Personagem alvo)
        {
            int dano = atacante.CalcularDano(_rng);
            int real = alvo.ReceberDano(dano);
            Console.ForegroundColor = ConsoleColor.Green;
            Display.EscreverLinha($"\n  Você golpeia {alvo.Nome} causando {real} de dano!");
            Console.ResetColor();
        }

        private static void TurnoDefender(Personagem jogador)
        {
            jogador.Defendendo = true;
            Console.ForegroundColor = ConsoleColor.Blue;
            Display.EscreverLinha("\n  Você ergue o escudo e se prepara para aparar o golpe!");
            Console.ResetColor();
        }

        private static bool TurnoFugir()
        {
            if (_rng.Next(100) < 45)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Display.EscreverLinha("\n  Você consegue escapar da batalha!");
                Console.ResetColor();
                return true;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Display.EscreverLinha("\n  Você tenta fugir, mas o inimigo bloqueia sua saída!");
            Console.ResetColor();
            return false;
        }

        //Turno do inimigo

        private static void TurnoInimigo(Personagem inimigo, Personagem jogador)
        {
            inimigo.Defendendo = false;

            if (_rng.Next(100) < 80)
            {
                // 20% de chance de errar o ataque
                if (_rng.Next(100) < 20)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Display.EscreverLinha($"\n  {inimigo.Nome} ataca mas erra o golpe!");
                    Console.ResetColor();
                }
                else
                {
                    int dano = inimigo.CalcularDano(_rng);
                    int real = jogador.ReceberDano(dano);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Display.EscreverLinha($"\n  {inimigo.Nome} contra-ataca causando {real} de dano em você!");
                    Console.ResetColor();
                }
            }
            else
            {
                inimigo.Defendendo = true;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Display.EscreverLinha($"\n  {inimigo.Nome} recua e fortalece sua guarda!");
                Console.ResetColor();
            }
        }

        //Resultado

        private static bool ProcessarResultado(
            Jogador    jogador,
            Personagem inimigo,
            int        xpRecompensa,
            int        ouroRecompensa)
        {
            if (jogador.EstaVivo)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Display.Separador();
                Display.EscreverLinha($"\n   Vitória! {inimigo.Nome} foi derrotado!");
                Display.EscreverLinha($"  + {xpRecompensa} XP  |  + {ouroRecompensa} Ouro\n");
                Display.Separador();
                Console.ResetColor();

                jogador.GanharXP(xpRecompensa);
                jogador.Ouro += ouroRecompensa;
                Display.Pausa();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Display.Separador();
                Display.EscreverLinha("\n  ✝  Você foi derrotado...\n");
                Display.Separador();
                Console.ResetColor();
                Display.Pausa();
                return false;
            }
        }

        private static string LerEscolha(bool podeFugir)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nO que deseja fazer?");
            Console.WriteLine("  [1] Atacar");
            Console.WriteLine("  [2] Defender");
            if (podeFugir) Console.WriteLine("  [3] Fugir");
            Console.Write("\nEscolha: ");
            Console.ResetColor();
            return Console.ReadLine()?.Trim() ?? "";
        }
    }
}
