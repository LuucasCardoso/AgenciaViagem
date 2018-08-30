using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Usuario
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email inválido!")]
        [Column(Order = 1)]
        public string Email { get; set; }
        [Required]
        [Column(Order = 2)]
        public string Password { get; set; }
        [Required]
        [Range(4, 12, ErrorMessage = "O usuário deve conter entre 4 e 12 caracteres!")]
        [Column(Order = 3)]
        public string User { get; set; }
        [Column(Order = 4)]
        public bool Administrador { get; set; }
        public bool Ativo { get; set; }
    }
}
