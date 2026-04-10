namespace CavaleiroDosSetReinos.UI
{
    public static class Display
    {

        //  texto caractere por caractere com delay
        public static void Escrever(string texto, int delay = 25)
        {
            foreach (char c in texto)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        //linha animada
        public static void EscreverLinha(string texto = "", int delay = 25)
        {
            Escrever(texto, delay);
            Console.WriteLine();
        }

        //linha separadora em vermelho escuro
        public static void Separador()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("══════════════════════════════════════════════════════════");
            Console.ResetColor();
        }

        //pressionar qualquer tecla limpa a tela
        public static void Pausa()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            EscreverLinha("\n[ Pressione qualquer tecla para continuar... ]", 0);
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
        }


        //status jogador
        public static void ExibirStatusJogador(Models.Jogador jogador)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                $"\n[ {jogador.Nome} | Nível {jogador.Nivel} | " +
                $"Vida: {jogador.Vida}/{jogador.VidaMax} | " +
                $"ATK: {jogador.Ataque} | DEF: {jogador.Defesa} | " +
                $"XP: {jogador.XP}/{jogador.XPProximo} | Ouro: {jogador.Ouro} ]");
            Console.ResetColor();
        }

        //status inimigo
        public static void ExibirStatusInimigo(Models.Personagem inimigo)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"[ {inimigo.Nome} | Vida: {inimigo.Vida}/{inimigo.VidaMax} | " +
                $"ATK: {inimigo.Ataque} | DEF: {inimigo.Defesa} ]");
            Console.ResetColor();
        }

        //Telas 

        //tela de abertura
        public static void TelaAbertura()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
  ██████╗ █████╗ ██╗   ██╗ █████╗ ██╗     ███████╗██╗██████╗  ██████╗
 ██╔════╝██╔══██╗██║   ██║██╔══██╗██║     ██╔════╝██║██╔══██╗██╔═══██╗
 ██║     ███████║██║   ██║███████║██║     █████╗  ██║██████╔╝██║   ██║
 ██║     ██╔══██║╚██╗ ██╔╝██╔══██║██║     ██╔══╝  ██║██╔══██╗██║   ██║
 ╚██████╗██║  ██║ ╚████╔╝ ██║  ██║███████╗███████╗██║██║  ██║╚██████╔╝
  ╚═════╝╚═╝  ╚═╝  ╚═══╝  ╚═╝  ╚═╝╚══════╝╚══════╝╚═╝╚═╝  ╚═╝ ╚═════╝
            ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("              D O S   S E T E   R E I N O S");
            Console.WriteLine("          Um Jogo de Turnos em Westeros\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                Pressione qualquer tecla...");
            Console.ResetColor();
            Console.ReadKey(true);
            Console.Clear();
        }

        //tela de Game Over
        public static void TelaGameOver(Models.Jogador jogador)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
   ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
  ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
  ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
  ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
  ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
   ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝
            ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            EscreverLinha($"\n  {jogador.Nome} caiu em batalha.", 20);
            EscreverLinha("  As histórias dirão que ele lutou com honra — como manda a lei do Norte.", 20);
            EscreverLinha("\n  Westeros não esquece seus mortos.", 20);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n  Nível alcançado : {jogador.Nivel}");
            Console.WriteLine($"  Ouro acumulado  : {jogador.Ouro} peças\n");
            Console.ResetColor();
            Console.WriteLine("  Pressione qualquer tecla para sair...");
            Console.ReadKey(true);
        }

        //tela de vitória final com estatísticas.
        public static void TelaVitoria(Models.Jogador jogador)
        {
            Console.Clear();
            Separador();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
   ██╗   ██╗██╗████████╗ ██████╗ ██████╗ ██╗ █████╗ 
   ██║   ██║██║╚══██╔══╝██╔═══██╗██╔══██╗██║██╔══██╗
   ██║   ██║██║   ██║   ██║   ██║██████╔╝██║███████║
   ╚██╗ ██╔╝██║   ██║   ██║   ██║██╔══██╗██║██╔══██║
    ╚████╔╝ ██║   ██║   ╚██████╔╝██║  ██║██║██║  ██║
     ╚═══╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═╝
            ");
            Console.ResetColor();
            Separador();

            Console.ForegroundColor = ConsoleColor.Gray;
            EscreverLinha($"\n  Com A Montanha derrotada, os portões se abrem.", 20);
            EscreverLinha($"  Você entra em Porto Real com passos pesados, mas cabeça erguida.", 20);
            EscreverLinha($"\n  O povo sussurra seu nome pelas ruelas: {jogador.Nome}.", 20);
            EscreverLinha($"  Um cavaleiro que percorreu os Sete Reinos por honra e justiça.", 20);
            EscreverLinha($"\n  O Trono de Ferro ainda aguarda seu verdadeiro rei —", 20);
            EscreverLinha($"  mas hoje, Westeros tem um novo herói.", 20);
            EscreverLinha($"\n  E o inverno... o inverno pode esperar um pouco mais.", 20);
            Console.ResetColor();

            Console.WriteLine();
            Separador();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n  ═══ ESTATÍSTICAS FINAIS ═══");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Cavaleiro  : {jogador.Nome}");
            Console.WriteLine($"  Nível      : {jogador.Nivel}");
            Console.WriteLine($"  Vida Final : {jogador.Vida}/{jogador.VidaMax}");
            Console.WriteLine($"  Ouro       : {jogador.Ouro} peças");
            Console.ResetColor();
            Separador();
            Console.WriteLine("\n  Obrigado por jogar — O Inverno Está Chegando.\n");
            Console.ReadKey(true);
        }
    }
}
