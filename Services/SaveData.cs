using System.Text.Json;
using Projektv2.Models;


namespace Projektv2.Services
{
    internal class SaveData
    {
        private static string url =>
        Path.Combine(FileSystem.AppDataDirectory, "counter.json");

        // Zapisywanie liczników
        public static async Task Save(List<Counter> counter)
        {
            string json = JsonSerializer.Serialize(counter);

            await File.WriteAllTextAsync(url, json);
        }

        // Odczytywanie liczników
        public static async Task<List<Counter>> Upload()
        {
            if (!File.Exists(url))
                return new List<Counter>();

            string json = await File.ReadAllTextAsync(url);

            return JsonSerializer.Deserialize<List<Counter>>(json)
                   ?? new List<Counter>();
        }
    }
}
