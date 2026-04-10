using CavaleiroDosSetReinos.Models;
using CavaleiroDosSetReinos.UI;
using CavaleiroDosSetReinos.Combat;

namespace CavaleiroDosSetReinos.Story
{
    public static class Historia
    {

        public static void Narrar(string titulo, string[] linhas)
        {
            Console.Clear();
            Display.Separador();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Display.EscreverLinha($"\n  {titulo}\n");
            Console.ResetColor();
            Display.Separador();
            Console.WriteLine();

            foreach (string linha in linhas)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Display.EscreverLinha("  " + linha, 20);
                Console.ResetColor();
                Thread.Sleep(70);
            }

            Display.Pausa();
        }

        public static void Descanso(Jogador jogador, int cura, string narrativa)
        {
            Console.Clear();
            Display.Separador();
            Console.ForegroundColor = ConsoleColor.Green;
            Display.EscreverLinha("\n  Acampamento\n");
            Console.ResetColor();
            Display.Separador();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
            Display.EscreverLinha("  " + narrativa, 20);
            Console.ResetColor();

            int curado = Math.Min(cura, jogador.VidaMax - jogador.Vida);
            jogador.Vida += curado;

            Console.ForegroundColor = ConsoleColor.Green;
            Display.EscreverLinha(
                $"\n  Você recupera {curado} pontos de vida. " +
                $"(Vida atual: {jogador.Vida}/{jogador.VidaMax})");
            Console.ResetColor();
            Display.Pausa();
        }


        //prólogo
        public static void Prologo(Jogador jogador)
        {
            Narrar("PRÓLOGO — A Chamada das Espadas", new[]
            {
                "O vento sopra frio sobre as planícies de Westeros.",
                "Os corvos levam más notícias de Porto Real: o Rei Robert Baratheon",
                "está morto. Os Lannister tomaram o Trono de Ferro.",
                "",
                $"Você é {jogador.Nome}, um cavaleiro errante do Norte,",
                "fiel à Casa Stark e à memória de um rei justo.",
                "",
                "Com sua espada enferrujada e a honra por escudo,",
                "você parte em direção ao sul — rumo a Porto Real —",
                "sabendo que a guerra dos Cinco Reis está prestes a engolir",
                "todos os que ainda acreditam que o inverno não perdoa traidores.",
            });
        }

        //Capítulo 1
        public static bool Capitulo1(Jogador jogador, string nomeBase)
        {
            Narrar("CAPÍTULO I — As Estradas de Pedra dos Westerlands", new[]
            {
                "As rotas que cortam os Westerlands estão infestadas de soldados da Casa Lannister.",
                "Com suas armaduras douradas e o leão rugindo no peito,",
                "eles cobram pedágio de sangue de qualquer viajante que ouse passar.",
                "",
                "Ao dobrar uma curva entre penhascos acinzentados,",
                "você se depara com um soldado Lannister bloqueando o caminho.",
                "",
                $"— Ei, nordista! Ninguém passa por aqui sem pagar tributo.",
                "  Pelo ouro ou pela vida — você escolhe.",
                "",
                "Você ergue os olhos para o brasão do leão e aperta o cabo de sua espada.",
            });

            Personagem soldado = new Personagem(
                "Soldado Lannister", vida: 60, ataque: 14, defesa: 3);

            bool? resultado = SistemaCombate.Iniciar(
                jogador, soldado, xpRecompensa: 30, ouroRecompensa: 15);

            if (resultado == false) return false;   // jogador morreu

            if (resultado == null)
            {
                Narrar("Fuga nas Pedras", new[]
                {
                    "Você recua para os arbustos e espera o soldado passar.",
                    "A honra arranhada, mas a pele intacta.",
                    "Você encontra outro caminho e segue viagem para o sul.",
                });
            }
            else
            {
                Narrar("Vitória nas Estradas", new[]
                {
                    "O soldado cai com um gemido sobre o cascalho.",
                    "Você encontra algumas moedas em sua bolsa e pega sua espada.",
                    "Com passos apressados, retoma o caminho antes que outros Lannisters apareçam.",
                });
            }
            Descanso(jogador, 30,
                "Você arma acampamento à beira de um riacho gelado. " +
                "Um fogo pequeno, pão duro e memórias de Winterfell.");

            return true;
        }

        //Capítulo 2
        public static bool Capitulo2(Jogador jogador, string nomeBase)
        {
            Narrar("CAPÍTULO II — A Floresta dos Lobos-Gigantes", new[]
            {
                "Você adentrou a Floresta das Suspeitas, ao sul das Terras dos Rios.",
                "Dizem que um bando de mercenários da Companhia Dourada",
                "patrulha essas terras a mando da Rainha Cersei.",
                "",
                "Entre galhos retorcidos e névoa densa,",
                "uma figura encapuzada salta de uma árvore à sua frente.",
                "Uma adaga reluz na mão esquerda; veneno goteja da ponta.",
                "",
                $"— Ser {nomeBase}... seu nome está na minha lista.",
                "  A Rainha paga bem por cabeças de cavaleiros do Norte.",
                "",
                "Não há como fugir dessa — o assassino conhece cada trilha da floresta.",
            });

            Personagem assassino = new Personagem(
                "Assassino da Companhia Dourada", vida: 80, ataque: 20, defesa: 6);

            bool? resultado = SistemaCombate.Iniciar(
                jogador, assassino,
                xpRecompensa: 55, ouroRecompensa: 30,
                podeFugir: false);

            if (resultado == false) return false;

            Narrar("O Segredo do Assassino", new[]
            {
                "Com o assassino no chão, você encontra em sua bolsa",
                "um pergaminho com a lista de alvos de Cersei.",
                "Seu nome está lá — junto com os de Tyrion Lannister e Jon Snow.",
                "",
                "Você guarda o pergaminho. Pode ser útil mais à frente.",
                "A floresta silencia como se Westeros também prendesse a respiração.",
            });

            Descanso(jogador, 40,
                "Você se abriga numa cabana abandonada de um maester. " +
                "Cataplasmas de ervas selam os seus ferimentos enquanto " +
                "o vento uiva como um lobo-gigante lá fora.");

            return true;
        }

        //Capítulo 3
        public static bool Capitulo3(Jogador jogador, string nomeBase)
        {
            Narrar("CAPÍTULO III — Os Portões de Porto Real", new[]
            {
                "Porto Real se ergue diante de você como uma ferida aberta no mundo.",
                "A Fortaleza Vermelha domina o horizonte, tão intimidante quanto",
                "a própria crueldade dos que a habitam.",
                "",
                "Mas antes de alcançar os portões, um gigante bloqueia sua passagem.",
                "Ser Gregor Clegane — O Montanha — erguido como uma torre de aço.",
                "Sua espada de dois metros parece um brinquedo em suas mãos.",
                "",
                $"— Mais um fanático do Norte — ele rosna, a voz como trovão.",
                "  Cersei ordenou que nenhum cavaleiro leal aos Stark entrasse vivo.",
                "",
                "Você olha para a Fortaleza Vermelha ao longe, pensa em Ned Stark,",
                "em todos os que morreram por honra, e empunha sua espada.",
                "",
                "Este é o combate que define tudo.",
            });

            //o montanho reduz a defesa do jogador
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Display.EscreverLinha("\n  O Montanha é um inimigo extremamente perigoso!");
            Display.EscreverLinha("   Sua presença esmaga o espírito — você sente sua defesa enfraquecer.\n");
            Console.ResetColor();

            int defesaOriginal = jogador.Defesa;
            jogador.Defesa = Math.Max(1, jogador.Defesa - 3);
            Thread.Sleep(1200);

            Personagem montanha = new Personagem(
                "Ser Gregor Clegane — A Montanha", vida: 120, ataque: 28, defesa: 8);

            bool? resultado = SistemaCombate.Iniciar(
                jogador, montanha,
                xpRecompensa: 100, ouroRecompensa: 60,
                podeFugir: false);

            jogador.Defesa = defesaOriginal; 

            if (resultado == false) return false;

            return true;
        }
    }
}
