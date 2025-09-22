/*Desenvolvido por:
  
  Pedro Xavier Oliveira CB3027376
  Leandro Felix Nunes CB3026159

 */

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BLContainerManager.Models
{

    public class Container
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O número do container é obrigatório.")]
        [StringLength(11)]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Selecione o tipo do container.")]
        public string Tipo { get; set; } // Dry ou Refeer

        [Required(ErrorMessage = "Selecione o tamanho do container.")]
        [Range(20, 40, ErrorMessage = "O tamanho deve ser 20 ou 40 pés.")]
        public int Tamanho { get; set; } // 20 ou 40

        [Required(ErrorMessage = "Selecione um BL.")]
        public int BLID { get; set; } // Chave estrangeira

        [ValidateNever]
        public BL BL { get; set; } // Navegação para o BL
    }

}
