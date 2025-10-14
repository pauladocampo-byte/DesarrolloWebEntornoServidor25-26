namespace Forum.Models
{
    public static class MensajeRepository
    {
        private static readonly Dictionary<string, List<Mensaje>> _data =
          new()
          {
              ["asp.net"] = new List<Mensaje>
              {
                    new() { Autor="Paula",   Texto="Bienvenidos al foro de ASP.NET" },
                    new() { Autor="Alumno",  Texto="¿Cómo funciona el routing?" }
              },
              ["csharp"] = new List<Mensaje>
              {
                    new() { Autor="Profe",  Texto="Repaso de POO: herencia e interfaces" }
              }
          };
        public static IList<Mensaje> GetByForum(string forumName)
        {
          
            forumName = (forumName ?? "").ToLowerInvariant();
            return _data.TryGetValue(forumName, out var lista)
                ? lista
                : new List<Mensaje>();
        }
    }
}
