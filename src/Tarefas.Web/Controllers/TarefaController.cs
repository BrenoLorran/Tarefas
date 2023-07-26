using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<TarefaViewModel> listaDetarefas = new List<TarefaViewModel>();

        public TarefaController()
        {
            var tarefa1 = new TarefaViewModel();  
            tarefa1.Id = 1;                    
            tarefa1.Descricao = "Passaear com o Cachorro";
            tarefa1.Titulo = "Cachorro";
            tarefa1.Status = "Ativo";

            var tarefa2 = new TarefaViewModel();
            tarefa2.Id = 2;
            tarefa2.Descricao = "Comprar pão doce";
            tarefa2.Titulo = "Pão";
            tarefa1.Status = "Concluido";

            listaDetarefas.Add(tarefa1);
            listaDetarefas.Add(tarefa2);
            
        } 
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(TarefaViewModel tarefa)
        {
            return View();
        }
        public IActionResult Listagem()        
        {   

           return View(listaDetarefas);
        }

        public IActionResult Detalhar(int id)
        {
            var tarefa = listaDetarefas.FirstOrDefault(f=>f.Id==id);

            return View(tarefa);
        }
    }

}

