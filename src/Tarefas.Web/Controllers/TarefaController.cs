using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using System.Collections.Generic;

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
           var tarefaDTO = new TarefaDTO()
           {
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Status = tarefa.Status  
           };   

           var tarefaDAO = new TarefaDAO();
           tarefaDAO.Criar(tarefaDTO);

           return View();  
        }
        public IActionResult Listagem()        
        {   
            var TarefaDAO = new TarefaDAO();
            var listaDetarefasDTO = TarefaDAO.Consultar();
            var listaDetarefas = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDetarefasDTO)
            {
                listaDetarefas.Add(new TarefaViewModel()
                {
                    Id = tarefaDTO.Id,
                    Titulo = tarefaDTO.Titulo,
                    Descricao = tarefaDTO.Descricao,
                    Status = tarefaDTO.Status
                });
            }    

           return View(listaDetarefas);
        }

        public IActionResult Detalhar(int id)
        {
            var tarefaDAO = new TarefaDAO();
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Status = tarefaDTO.Status
    
            };
            return View(tarefa);
        }

        public IActionResult Update (int id)
        {
            var tarefaDAO = new TarefaDAO();
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Status = tarefaDTO.Status
    
            };
            return View(tarefa);
        }

        public IActionResult Deletar(int Id)
        {  
           var tarefaDAO = new TarefaDAO{};
           tarefaDAO.Deletar(Id);

           return RedirectToAction("Listagem");  
        }
        [HttpPost]
        public IActionResult Update (TarefaViewModel tarefa) 
        {
            var tarefaDTO = new TarefaDTO()
           {
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Status = tarefa.Status, 
            Id = tarefa.Id
           };   

           var tarefaDAO = new TarefaDAO();
           tarefaDAO.Update(tarefaDTO);

           return View();  
        }

    }

}

