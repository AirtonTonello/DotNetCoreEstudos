using LibSharedDLL;

if (Utility.TestDLL())
{
    foreach (var guid in Utility.TestGUIDList(10))
    {
        Console.WriteLine($"Guid DLL: {guid}");
    }
}
else
{
    Console.WriteLine("Não foi");
}

Console.ReadKey();