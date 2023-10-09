using System.Text.Json;
namespace webapi
{
    public class AccesoATareas
    {
        public List<Tarea> Obtener()
        {
            string LasTareas = File.ReadAllText("Models/tareas.json");
            List<Tarea> tareas;
            tareas = JsonSerializer.Deserialize<List<Tarea>>(LasTareas);

            return tareas;
        }

        public void Guardar(List<Tarea> ListaTareas)
        {
            string contenido = JsonSerializer.Serialize(ListaTareas);
            File.WriteAllText("Models/tareas.json", contenido);
        }
    }
}