using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;



namespace Tarefas.Web.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {
        private static List<TarefaViewModel> listaDetarefas = new List<TarefaViewModel>();
        private static int detalheId = 0;
        private readonly IMapper _mapper;
        private TarefaDAO tarefaDAO;
        private readonly ITarefaDAO _tarefaDAO;                     

        public TarefaController(IMapper mapper, ITarefaDAO tarefaDAO)
        {
            _mapper = mapper;
            _tarefaDAO = tarefaDAO;          

        }        
        
        public IActionResult Criar()
        {
            return View();
        }       
       
        [HttpPost]
        public IActionResult Criar(TarefaViewModel tarefa)
        {
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            _tarefaDAO.Criar(tarefaDTO);

            return View();
        }
        public IActionResult Listagem()
        {
            
            var listaDetarefasDTO = _tarefaDAO.Consultar();
            var listaDetarefas = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDetarefasDTO)
            {
                listaDetarefas.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
            }

            return View(listaDetarefas);
        }

        public IActionResult Detalhar(int id)
        {
            
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            return View(tarefa);
        }

        public IActionResult Update(int id)
        {
           
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            if (ModelState.IsValid)
            {
                return View(tarefa);
            }

            return View(tarefa);
        }

        public IActionResult Deletar(int Id)
        {
            
            _tarefaDAO.Deletar(Id);

            return RedirectToAction("Listagem");
        }
        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa)
        {
            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
           
            _tarefaDAO.Update(tarefaDTO);

            return View();
        }   

            
    }

}

