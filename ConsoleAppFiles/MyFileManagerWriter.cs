using ByteBankIO;
using System.Text;

namespace ConsoleAppFiles
{
    internal partial class MyFileManagerWriter : IDisposable
    {
        private readonly FileStream _fileStream;

        public MyFileManagerWriter(string file)
        {
            _fileStream = new FileStream(file, FileMode.CreateNew);
        }

        public void Dispose()
        {
            _fileStream.Close();
            _fileStream.Dispose();
        }
    }

    internal partial class MyFileManagerWriter
    {
        public async Task CriarArquivo()
        {
            string text = "Airton,Airton,Airton";

            var bytes = Encoding.UTF8.GetBytes(text);

            await _fileStream.WriteAsync(bytes, 0, bytes.Length);
            await _fileStream.FlushAsync();
        }
    }

    internal partial class MyFileManagerWriter
    {
        public async Task CriarArquivoComWriter()
        {
            string text = "Airton,Airton,Airton";

            using StreamWriter writer = new(_fileStream, Encoding.UTF8)
            {
                AutoFlush = true
            };

            var random = new Random();
            var total = random.Next(10000, 1000000);

            for (var index = 0; index < total; index++)
                await writer.WriteLineAsync(text).ConfigureAwait(false);
        }
    }

    internal partial class MyFileManagerWriter
    {
        public async Task CriarArquivoComFlush(int total)
        {
            string text = "Airton,Airton,Airton";

            using StreamWriter writer = new(_fileStream, Encoding.UTF8);

            int currentBuffer = 0;

            for (var index = 0; index < total; index++)
            {
                await writer.WriteLineAsync(text);

                if (currentBuffer > 1000 || (index + 1) == total)
                {
                    // despesa no arquivo o buffer
                    await writer.FlushAsync();
                    currentBuffer = 0;

                    Console.Write("\rLinhas: {0} / {1}", index + 1, total);
                }

                currentBuffer++;
            }
        }
    }

    internal partial class MyFileManagerWriter
    {
        public async Task CriarArquivoBinario(int total)
        {
            await Task.Yield();

            string text = "Airton,Airton,Airton\n";

            using BinaryWriter binary = new(_fileStream);

            int currentBuffer = 0;

            for (var index = 0; index < total; index++)
            {
                binary.Write(text);

                if (currentBuffer > 1000 || (index + 1) == total)
                {
                    // despesa no arquivo o buffer
                    binary.Flush();
                    currentBuffer = 0;

                    Console.Write("\rLinhas: {0} / {1}", index + 1, total);
                }

                currentBuffer++;
            }
        }
    }
}
