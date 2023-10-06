namespace ConsoleAppFiles
{
    internal static class MyConsole
    {
        public static void Input()
        {
            using var consoleStream = Console.OpenStandardInput();
            using var fileStream = new FileStream(@"c:\temp\console", FileMode.Create);

            byte[] buffer = new byte[1024];

            while (true)
            {
                var totalLidos = consoleStream.Read(buffer, 0, buffer.Length);
                Console.WriteLine(totalLidos);

                fileStream.Write(buffer, 0, totalLidos);
                fileStream.Flush();
            }
        }
    }
}
