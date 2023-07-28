namespace OperacaoMatematica.Dominio.Core.Utils
{
    public class BadRequestRetorno
    {

        public bool success { get; set; }
        public List<string> errors { get; set; }

        public BadRequestRetorno()
        {
            success = false;
        }
    }
}
