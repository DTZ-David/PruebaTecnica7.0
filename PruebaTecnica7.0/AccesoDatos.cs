namespace PruebaTecnica
{
    public class AccesoDatos
    {
        private string cadenaMongo;
        public string CadenaConexionMongo { get => cadenaMongo; }

        public AccesoDatos(string conexion)
        {
            cadenaMongo = conexion;
        }
    }
}
