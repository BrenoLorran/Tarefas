using System.ComponentModel.DataAnnotations; 

namespace Tarefas.Web.Models
{
    public class TarefaViewModel
    {
        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

       [Required(ErrorMessage = "A Descrição deve ser preenchida")]
        [MinLength(4, ErrorMessage = "A quantidade minima deve ser 4 caracteres")]
        [MaxLength(100, ErrorMessage = "A quatidade maxima deve ser 100 caracteres")] 
        [System.ComponentModel.DisplayName("Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O Titulo deve ser preenchida")]
        [MinLength(4, ErrorMessage = "A quantidade minima deve ser 4 caracteres")]
        [MaxLength(100, ErrorMessage = "A quatidade maxima deve ser 100 caracteres")]
        [System.ComponentModel.DisplayName("Título")]
        public string? Titulo { get; set; }

       [Required(ErrorMessage = "O Status deve ser preenchida")]
        [MinLength(4, ErrorMessage = "A quantidade minima deve ser 4 caracteres")]
        [MaxLength(20, ErrorMessage = "A quatidade maxima deve ser 20 caracteres")] 
        [System.ComponentModel.DisplayName("Status")]
       public string? Status { get; set; }       
        
        }       

}