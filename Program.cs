using System.Diagnostics;

internal class Program
{
    static async Task Main(string[] args)
    {
        string rethinkPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Executables", "rethinkdb.exe");

        if (!File.Exists(rethinkPath))
        {
            Console.WriteLine($"[!] rethinkdb.exe не найден: {rethinkPath}");
            return;
        }

        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = rethinkPath,
                Arguments = "--directory rethinkdb_data", // или другой каталог, если хочешь
                WorkingDirectory = Path.GetDirectoryName(rethinkPath)!,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        process.Start();
        Console.WriteLine("[✓] rethinkdb.exe запущен");

        await Task.Delay(-1); // оставим процесс живым
    }
}
