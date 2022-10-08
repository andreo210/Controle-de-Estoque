using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    [Table("Cidade")]
    public class CidadeEntity
    {
      
        [Key]        
        public int Id { get; set; }

        [Required, MaxLength(30)]
        [Column("nome")]
        public string Nome { get; set; }


        [Required]
        [Column("nome")]
        public bool Ativo { get; set; }

        [Required]
        [Column("id_estado")]
        public int IdEstado { get; set; }

        [Required, ForeignKey("IdEstado")]
        [Column("estado")]
       
        public EstadoEntity Estado { get; set; }
        
    }
}
