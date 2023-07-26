namespace Tarefas.Web.Models
{

    public class TarefaViewModel
    {

        public int Id { get; set; }

         [System.ComponentModel.DisplayName("Descricao")]
         public string Descricao { get; set; }

        [System.ComponentModel.DisplayName("Titulo")]
         public string Titulo { get; set; }

         [System.ComponentModel.DisplayName("Status")]
         public string Status { get; set; }
     }

}