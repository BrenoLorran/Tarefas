

namespace Tarefas.Web.Models
{
    public class TarefaViewModel
    {
         [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; }

         [System.ComponentModel.DisplayName("Descrição")]
         public string? Descricao { get; set; }

        [System.ComponentModel.DisplayName("Título")]
         public string? Titulo { get; set; }

         [System.ComponentModel.DisplayName("Status")]
         public string? Status { get; set; }
     }

}