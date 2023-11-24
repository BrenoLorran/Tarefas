using System;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using System.Collections.Generic;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;



namespace Usuario.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private static List<UsuarioViewModel> listaDeUsuario = new List<UsuarioViewModel>();
        private static int detalheId = 0;
        private readonly IMapper _mapper;
        private UsuarioDAO usuarioDAO;
        private readonly IUsuarioDAO _usuarioDAO;                     

        public UsuarioController(IMapper mapper, IUsuarioDAO usuarioDAO)
        {
            _mapper = mapper;
            _usuarioDAO = usuarioDAO;          

        }

        public IActionResult Autenticar()
        {
            return View();
        } 
        
        public IActionResult Criar()
        {
            return View();
        }       
       
        [HttpPost]
        [Authorize]
        public IActionResult Criar(UsuarioViewModel tarefa)
        {
            var usuarioDTO = _mapper.Map<UsuarioDTO>(tarefa);
          /*  if (!ModelState.IsValid)
            {
                return View();
            }*/
            
            _usuarioDAO.Criar(usuarioDTO);

            return View();
        }
         [Authorize]
        public IActionResult Listagem()
        {
            
            var listaDeusuarioDTO = _usuarioDAO.ConsultarUsuario();
            var listaDeusuario = new List<UsuarioViewModel>();

            foreach (var usuarioDTO in listaDeusuarioDTO)
            {
                listaDeusuario.Add(_mapper.Map<UsuarioViewModel>(usuarioDTO));
            }

            return View(listaDeusuario);
        }
         [Authorize]
        public IActionResult Detalhar(int id)
        {
            
            var tarefaDTO = _usuarioDAO.ConsultarUsuario(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            return View(tarefa);
        }
         [Authorize]
        public IActionResult Update(int id)
        {
           
            var usuarioDTO = _usuarioDAO.ConsultarUsuario(id);

            var usuario = _mapper.Map<UsuarioViewModel>(usuarioDTO);

            if (ModelState.IsValid)
            {
                return View(usuario);
            }

            return View(usuario);
        }
        [Authorize]
        public IActionResult Deletar(int Id)
        {
            
            _usuarioDAO.DeletarUsuario(Id);

            return RedirectToAction("Listagem");
        }
        [HttpPost]
        [Authorize]
        public IActionResult Update(UsuarioViewModel usuario)
        {
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);
           
            _usuarioDAO.Update(usuarioDTO);

            return View();
        }   

         public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidarUsuario(LoginViewModel usuario)
        {
            if(ModelState.IsValid)
            {

            var UsuarioDTO = _mapper.Map<UsuarioDTO>(usuario); 
            UsuarioDTO user;

            try
            {
                 user = _usuarioDAO.ValidarUsuario(UsuarioDTO);  
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View ("Index");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Email, user.Email)
            };

           var claimsIdentity  = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

           var authProperts = new AuthenticationProperties
           {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            IsPersistent = true, 
            RedirectUri = "/Home"
           };

           HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal (claimsIdentity), authProperts);
            return LocalRedirect(authProperts.RedirectUri);          
           
            }

            return View("Index");
        } 
            
    }

}

