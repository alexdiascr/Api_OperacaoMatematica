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
        [StringLength(150, MinimumLength = 5, ErrorMessage = "O tamanho do campo nome deve ser de 5 a 150 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Primeiro valor")]
        [Required(ErrorMessage = "Primeiro valor é obrigatório.")]
        public double PrimeiroValor { get; set; }


        [Display(Name = "Segundo valor")]
        [Required(ErrorMessage = "Segundo valor é obrigatório.")]
        public double SegundoValor { get; set; }

        [Display(Name = "Operação matemática")]
        [Required(ErrorMessage = "Operação matemática é obrigatória.")]
        [MaxLength(1, ErrorMessage = "Somente é aceito um caracter")]
        public string OperadorMatematico { get; set; }

        public double Resultado { get; set; }
    }
}
