using LibSharedDLL;

if (Utility.TestDLL())
{
    //for (int i = 0; i < 10; i++)
    //{
    //    Console.WriteLine($"Guid DLL: {Utility.TestGUID()}");
    //}

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