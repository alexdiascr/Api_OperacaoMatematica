using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OperacaoMatematica.Application.ViewModels.Produto
{
    public class NumeroViewModel 
    {
        [Display(Name = "Data da operação.")]
        [Required(ErrorMessage = "Data da operação é obrigatório.")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Primeiro valor")]
        [Required(ErrorMessage = "Primeiro valor é obrigatório.")]
        public string PrimeiroValor { get; set; }


        [Display(Name = "Segundo valor")]
        [Required(ErrorMessage = "Segundo valor é obrigatório.")]
        public string SegundoValor { get; set; }

        [Display(Name = "Operação matemática")]
        [Required(ErrorMessage = "Operação matemática é obrigatória.")]
        public string OperadorMatematico { get; set; }
    }
}
