using ByteBankIO;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleAppFiles
{
    // partial -> massa demais
    internal partial class MyFileManagerReader : IDisposable
    {
        private readonly FileInfo _info;
        private readonly FileStream _fileStream;

        public MyFileManagerReader(string file)
        {
            _info = new(file);
            _fileStream = new FileStream(_info.FullName, FileMode.Open);
        }

        public void Dispose()
        {
            _fileStream.Close();
            _fileStream.Dispose();
        }
    }

    internal partial class MyFileManagerReader
    {
        public async Task LeBufferInicial(string file)
        {
            byte[] buffer = new byte[1024]; // 1KB

            await _fileStream.ReadAsync(buffer, 0, buffer.Length);

            void Escrever(byte[] buffer)
            {
                for (var index = 0; index < buffer.Length; index++)
                {
                    Console.Write(buffer[index]);
                }
            }

            Escrever(buffer);

            string text = Encoding.UTF8.GetString(buffer);

            Console.WriteLine();
            Console.WriteLine("{0}\n{1}", text, text.Length);
        }
    }

    internal partial class MyFileManagerReader
    {
        public async Task LerBuffer()
        {
            int partes = 0;
            byte[] buffer = new byte[1024]; // buffer de 1KB

            // toda vez que a função read é executada o seek passa a estar naquela posição então não preciso andar com o OffSet
            while (await _fileStream.ReadAsync(buffer, 0, buffer.Length) != 0)
            {
                string text = Encoding.UTF8.GetString(buffer);

                Console.WriteLine("{0}\n{1} | {2}\n", text, text.Length, partes);

                partes++;
            }
        }
    }

    internal partial class MyFileManagerReader
    {
        public async Task LerBufferUsandoUTF8()
        {
            byte[] buffer = new byte[1024]; // buffer de 1KB

            UTF8Encoding utf8 = new();

            while (await _fileStream.ReadAsync(buffer, 0, buffer.Length) != 0)
            {
                string text = utf8.GetString(buffer);
                Console.Write(text);
            }
        }
    }

    internal partial class MyFileManagerReader
    {
        public async Task LerBufferTestUsingLocal()
        {
            using var fileLocalStream = new FileStream(_info.FullName, FileMode.Open);

            byte[] buffer = new byte[1024]; // buffer de 1KB

            UTF8Encoding utf8 = new();

            while (await fileLocalStream.ReadAsync(buffer, 0, buffer.Length) != 0)
            {
                string text = utf8.GetString(buffer);
                Console.Write(text);
            }
        }
    }

    internal partial class MyFileManagerReader
    {
        // buffer estava sujo
        public async Task LerBufferFixed()
        {
            byte[] buffer = new byte[1024]; // buffer de 1KB

            UTF8Encoding utf8 = new();

            while (await _fileStream.ReadAsync(buffer, 0, buffer.Length) != 0)
            {
                string text = utf8.GetString(buffer);
                Console.Write(text);
                buffer = new byte[1024];
            }
        }
    }

    internal partial class MyFileManagerReader
    {
        private long totalLido = 0;
        private UTF8Encoding utf8 = new();

        // rodando recursivamente uma função encadea na outra, não liberando os recursos
        public async Task LerBufferRecursivo(int bufferLength = 1024)
        {
            byte[] buffer = new byte[bufferLength]; // buffer de 1KB

            totalLido += await _fileStream.ReadAsync(buffer.AsMemory(0, bufferLength));

            string text = utf8.GetString(buffer);
            Console.Write(text);

            if (totalLido < _info.Length)
                await LerBufferRecursivo(Math.Min(bufferLength, (int)(_info.Length - totalLido)));
        }
    }

    internal partial class MyFileManagerReader
    {
#nullable disable
        public async Task LerBufferComStreamReader()
        {
            using StreamReader reader = new(_fileStream);

            while (!reader.EndOfStream)
            {
                string text = await reader.ReadLineAsync();
                Console.WriteLine(text);
            }
        }
    }

    internal partial class MyFileManagerReader
    {
        public async Task LerContaCorrentes()
        {
            using StreamReader reader = new(_fileStream);

            while (!reader.EndOfStream)
            {
                string text = await reader.ReadLineAsync();

                var conta = ConverterString(text);

                Console.WriteLine("{0} | {1}", conta.Agencia, conta.Numero);
            }
        }

        public async IAsyncEnumerable<ContaCorrente> AsyncLerContaCorrentes()
        {
            using StreamReader reader = new(_fileStream);

            while (!reader.EndOfStream)
            {
                string text = await reader.ReadLineAsync();

                yield return ConverterString(text);
            }
        }

        private ContaCorrente ConverterString(string text)
        {
            var fields = text.Split(',');

            return new ContaCorrente(int.Parse(fields[0]), int.Parse(fields[1]));
        }
    }

    internal partial class MyFileManagerReader
    {
        public async Task LerBinario()
        {
            await Task.Yield();

            using BinaryReader binary = new(_fileStream);

            Console.WriteLine();

            string text = string.Empty;

            do
            {
                try
                {
                    text = binary.ReadString();
                    Console.Write(text);
                }
                catch
                {
                    text = string.Empty;
                }
                
            }
            while (!string.IsNullOrEmpty(text));
        }
    }
}
