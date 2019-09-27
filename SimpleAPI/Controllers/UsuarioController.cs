using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SimpleAPI.Models;
using SimpleAPI.Utils;

namespace SimpleAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        private MeuContext db = new MeuContext();

        /// <summary>
        /// Lista de Usuarios
        /// </summary>
        /// <returns>Retorna todos os Usuarios</returns>
        /// <response code="200">Retorna usuarios cadastrados</response>
        public IEnumerable<Usuario> GetUsuarios()
        {
            return db.Usuarios.AsEnumerable();
        }

        /// <summary>
        /// Busca Usuario por ID
        /// </summary>
        /// <returns>Retorna usuario</returns>
        /// <response code="200">Retorna usuarios cadastrados</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
                return BadRequest(Validacoes.UserNotExist);
            return Ok(usuario);
        }

        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <returns>Retorna usuario atualizado</returns>
        /// <response code="200">Retorna usuario atualizado</response>
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!Validacoes.IsValidEmail(usuario.Emailaddress))
                return BadRequest(Validacoes.EmailNotValid);
            if ((!Validacoes.IsCPFValid(usuario.Cpf)))
                return BadRequest(Validacoes.CPFNotValid);
            if (!Validacoes.IsPasswordValid(usuario.password))
                return BadRequest(Validacoes.PasswordNotValid);
            if (!UsuarioExists(id))
                return BadRequest(Validacoes.UserNotExist);

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch 
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Criar Usuario
        /// </summary>
        /// <returns>Retorna usuario criado</returns>
        /// <response code="200">Retorna usuario criado</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid )
                return BadRequest(ModelState);
            if (!Validacoes.IsValidEmail(usuario.Emailaddress))
                return BadRequest(Validacoes.EmailNotValid); 
            if ((!Validacoes.IsCPFValid(usuario.Cpf)))
                return BadRequest(Validacoes.CPFNotValid); 
            if (!Validacoes.IsPasswordValid(usuario.password))
                return BadRequest(Validacoes.PasswordNotValid);
            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
           
        }

        /// <summary>
        /// Deletar Usuario
        /// </summary>
        /// <returns>Retorna usuario deletado</returns>
        /// <response code="200">Retorna usuario deletado</response>
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
                return BadRequest(Validacoes.UserNotExist);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.Id == id) > 0;
        }
    }
}