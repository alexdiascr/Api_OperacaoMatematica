namespace SomaNumeros.Dominio.Core.Utils
{
    public class SucessRetorno<TViewModel>
      where TViewModel : class
    {
        public bool success { get; set; }
        public List<TViewModel> data { get; set; }
    }
}
