using webapi;

public class Manejo
{
    private AccesoATareas accesoATareas = new();
    private List<Tarea> listaTarea = new List<Tarea>();
    private int nroTareasCreadas;

    public AccesoATareas AccesoATareas { get => accesoATareas; set => accesoATareas = value; }
    public List<Tarea> ListaTarea { get => listaTarea; set => listaTarea = value; }
    public int NroTareasCreadas { get => nroTareasCreadas; set => nroTareasCreadas = value; }

    public static Manejo instance;

    public Manejo()
    {
        this.nroTareasCreadas=ListaTarea.Count;
        this.ListaTarea =  new List<Tarea>();
    }

    public static Manejo Instance()
    {
        if (instance ==null)
        {
            instance = new Manejo();
            instance.ListaTarea=instance.AccesoATareas.Obtener();
            instance.NroTareasCreadas=instance.ListaTarea.Count;
        }        
        return instance;
    }

    public void CrearTarea()
    {
        Tarea nuevaTarea = new Tarea(NroTareasCreadas+1);//incremento en uno el valor del id de la tarea
        NroTareasCreadas+=1;//incremento el numero de tareas creadas de manejo
        listaTarea.Add(nuevaTarea);
        Console.WriteLine("Se creo la tara nro: "+nuevaTarea.Id+ " y se lo agrego a la lista");
    }

    public void ActualizarTarea(int id, string titulo, string descripcion, string estado, Tarea TareaBuscada)
    {
        ListaTarea.Remove(TareaBuscada);
        TareaBuscada.Id=id;
        TareaBuscada.Titulo=titulo;
        TareaBuscada.Descripcion=descripcion;
        TareaBuscada.Estado=estado;
        ListaTarea.Add(TareaBuscada);
        AccesoATareas.Guardar(ListaTarea);
    }
}