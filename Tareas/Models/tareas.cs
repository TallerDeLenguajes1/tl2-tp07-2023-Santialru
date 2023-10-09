namespace webapi{
    public class Tarea
    {
        private int id;
        private string titulo;
        private string descripcion;
        private string estado;
        
        

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        
        public Tarea(int id)
        {
            this.id = id;
            this.titulo = "Tareatitulo";
            this.descripcion = null;
            this.estado = "Pendiente";
        }

        public void EstadoTarea()
        {
            Console.WriteLine("ASIGNAR/CAMBIAR ESTADO DE LA TAREA");
            Console.WriteLine("1:Pendiente, 2:EnProceso, 3:Compretada");
            int state;
            int.TryParse(Console.ReadLine(), out state);
            switch (state)
            {
                case 1:
                estado="Pendiente";
                break;
                case 2:
                estado="EnProceso";
                break;
                case 3:
                estado="Completada";
                break;

                default:
                    return;
            }
        }

        public void CambiarDescripcion()
        {
            Console.WriteLine("Ingrese la nueva descripcion de la tarea");
            descripcion = Console.ReadLine();
        }

        public void CambiarTitulo()
        {
            Console.WriteLine("ingrse nuevo titulo");
            titulo = Console.ReadLine();
        }


        public void ListarTarea()
        {
            Console.WriteLine("ID:"+Id);
            Console.WriteLine("Titulo:"+Titulo);
            Console.WriteLine("Descripcion:"+Descripcion);
            Console.WriteLine("Estado:"+Estado);
        }
    }
}