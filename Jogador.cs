using CavaleiroDosSetReinos.UI;

namespace CavaleiroDosSetReinos.Models
{
    public class Jogador : Personagem
    {
        public int Nivel     { get; private set; }
        public int XP        { get; private set; }
        public int XPProximo { get; private set; }
        public int Ouro      { get; set; }

        public Jogador(string nome) : base(nome, vida: 100, ataque: 18, defesa: 5)
        {
            Nivel     = 1;
            XP        = 0;
            XPProximo = 50;
            Ouro      = 0;
        }


        // subir de nível: vida máxima +20, ataque +4, defesa +2
        public void GanharXP(int quantidade)
        {
            XP += quantidade;

            while (XP >= XPProximo)
            {
                XP        -= XPProximo;
                Nivel++;
                XPProximo  = (int)(XPProximo * 1.5);
                VidaMax   += 20;
                Vida       = VidaMax;   // cura total ao subir de nível
                Ataque    += 4;
                Defesa    += 2;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Display.EscreverLinha(
                    $"\n  Você subiu para o Nível {Nivel}! " +
                    $"Vida ({VidaMax}), Ataque ({Ataque}) e Defesa ({Defesa}) aumentaram!\n");
                Console.ResetColor();
            }
        }
    }
}
