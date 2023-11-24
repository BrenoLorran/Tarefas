using System.ComponentModel.DataAnnotations; 

namespace Tarefas.Web.Models
{
    public class UsuarioViewModel
      {
         public int Id { get; set; }
      
         public string Email {get; set;}
       
        public string Senha { get; set; }
        
        public string Nome { get; set; }
        
        public bool Ativo { get; set; }  
        
        }       

}