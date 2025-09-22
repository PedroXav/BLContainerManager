/*Desenvolvido por:
  
  Pedro Xavier Oliveira CB3027376
  Leandro Felix Nunes CB3026159

 */

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLContainerManager.Models
{
    public class BL
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O número do BL é obrigatório.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O número do BL deve ter entre 3 e 20 caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O Consignee é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O Consignee deve ter entre 3 e 50 caracteres.")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "O nome do navio é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome do navio deve ter entre 2 e 50 caracteres.")]
        public string Navio { get; set; }

        [ValidateNever]
        public ICollection<Container> Containers { get; set; }
    }

}
