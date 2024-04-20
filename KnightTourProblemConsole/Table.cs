namespace KnightTourProblemConsole
{
    internal class Table
    {
        private readonly int n;

        public int[,] Posicoes { get; private set; }

        public Table(int n)
        {
            this.n = n;
            Posicoes = new int[this.n, this.n];
        }
    }
}
