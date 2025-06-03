namespace ProjektRowery
{
    class TerminalDisplay : IDisplay
    {
        public void WriteLine(string line) =>
            Console.WriteLine(line);
    }
}
