using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Email inválido!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "O campo user deve ter no máximo 12 dígitos!", MinimumLength = 4)]
        public string User { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage ="Nome precisa ter no máximo 30 caracteres!")]
        public string Nome { get; set; }
        [Required]
        [StringLength(11,ErrorMessage ="O campo CPF precisa ter 11 dígitos!")]
        public string Cpf { get; set; }
        [Required]
        [StringLength(14, ErrorMessage = "O campo Telefone precisa ter Código do País, do Estado e número!")]
        public string Telefone { get; set; }
        public bool Administrador { get; set; }
        public bool Ativo { get; set; }
    }
}
