using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entidades
{
    public class CidadeEntity
    {     
         
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public bool Ativo { get; set; }

        //uma cidade pertence a um estado
        public int IdEstado { get; set; }            
        public EstadoEntity Estado { get; set; }
        
    }
}
