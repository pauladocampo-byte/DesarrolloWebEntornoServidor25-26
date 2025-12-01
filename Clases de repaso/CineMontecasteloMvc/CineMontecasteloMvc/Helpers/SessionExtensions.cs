using System.Text;
using System.Text.Json;

namespace CineMontecasteloMvc.Helpers
{
    public static class SessionExtensions
    {
        // Serializa el objeto a JSON y lo guarda como bytes UTF-8 en sesión
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            string jsonString = JsonSerializer.Serialize(value);
            session.Set(key, Encoding.UTF8.GetBytes(jsonString));
        }

        // Lee los bytes de sesión, los convierte a string UTF-8 y deserializa a T
        public static T? GetObject<T>(this ISession session, string key)
        {
            if (!session.TryGetValue(key, out var bytes)) return default;
            string jsonString = Encoding.UTF8.GetString(bytes);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
