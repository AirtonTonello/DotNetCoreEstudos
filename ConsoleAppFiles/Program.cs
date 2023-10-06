using ByteBankIO;
using ConsoleAppFiles;


MyConsole.Input();

List<ContaCorrente> contas = new();

using (MyFileManagerReader myReader = new(@"C:\Users\airto\source\repos\DotNetCoreEstudos\contas.txt"))
{
    //await myReader.LerBuffer();

    //await myReader.LerBufferUsandoUTF8();

    //await myReader.LerBufferTestUsingLocal();

    //await myReader.LerBufferFixed();

    //await myReader.LerBufferRecursivo();

    //await myReader.LerBufferComStreamReader();

    //await foreach (var conta in myReader.AsyncLerContaCorrentes())
    //{
    //    contas.Add(conta);
    //}
}


var random = new Random();

var total = random.Next(10000, 1000000);

using (MyFileManagerWriter myWriter = new(@$"C:\Users\airto\source\repos\DotNetCoreEstudos\contas-{random.Next(0, 10000)}-normal.txt"))
{
    //await myWriter.CriarArquivo();
    //await myWriter.CriarArquivoComWriter();

    await myWriter.CriarArquivoComFlush(total);
    Console.WriteLine();
    Console.WriteLine();
}

using (MyFileManagerWriter myWriter = new(@$"C:\Users\airto\source\repos\DotNetCoreEstudos\contas-{random.Next(0, 10000)}-binario.txt"))
{
    await myWriter.CriarArquivoBinario(total);
}

//using (MyFileManagerReader binary = new(@$"C:\Users\airto\source\repos\DotNetCoreEstudos\contas-{aleatorio}.txt"))
//{
//    //await binary.LerBinario();
//}

Console.ReadKey();