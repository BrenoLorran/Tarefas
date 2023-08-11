using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        private static List<TarefaViewModel> listaDetarefas = new List<TarefaViewModel>();
        private static int detalheId = 0;

        public TarefaController()
        {        
            
        } 
        public IActionResult Criar()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Criar(TarefaViewModel tarefa)
        {
            tarefa.Id = detalheId++;
            listaDetarefas.Add(tarefa);
            return View("Listagem",listaDetarefas);            
        }
        public IActionResult Listagem(TarefaViewModel tarefa)        
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

