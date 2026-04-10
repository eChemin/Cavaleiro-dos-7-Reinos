namespace CavaleiroDosSetReinos.Models
{
    public class Personagem
    {
        public string Nome       { get; set; }
        public int    Vida       { get; set; }
        public int    VidaMax    { get; set; }
        public int    Ataque     { get; set; }
        public int    Defesa     { get; set; }
        public bool   Defendendo { get; set; }

        public Personagem(string nome, int vida, int ataque, int defesa)
        {
            Nome       = nome;
            VidaMax    = vida;
            Vida       = vida;
            Ataque     = ataque;
            Defesa     = defesa;
            Defendendo = false;
        }

        //retorna true enquanto o personagem tiver vida 0
        public bool EstaVivo => Vida > 0;


        public int ReceberDano(int dano)
        {
            int reducao   = Defendendo ? Defesa * 2 : Defesa;
            int danoFinal = Math.Max(1, dano - reducao);
            Vida          = Math.Max(0, Vida - danoFinal);
            return danoFinal;
        }

        public int CalcularDano(Random rng)
        {
            double variacao = 0.8 + rng.NextDouble() * 0.4; // entre 0.8 e 1.2
            return (int)(Ataque * variacao);
        }
    }
}
