using Alura.ByteBank.Dados.Contexto;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.Dados.Repositorio
{
    public class UsuarioAppRepositorio : IUsuarioRepositorio
    {
        private readonly ByteBankContexto _contexto;
        public UsuarioAppRepositorio()
        {
            _contexto = new ByteBankContexto();
        }
        public bool Adicionar(UsuarioApp usuario)
        {
            try
            {
                _contexto.Usuarios.Add(usuario);
                _contexto.SaveChanges();

                return true;
            }
            catch{
                return false;
            }
        }

        public bool Atualizar(int id, UsuarioApp usuario)
        {
            
            try
            {
                if (id != usuario.Id)
                {
                    return false;
                }
                _contexto.Entry(usuario).State = EntityState.Modified;
                _contexto.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }

        public bool Excluir(int id)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(p => p.Id == id);

            try
            {
                if (usuario == null)
                {
                    return false;
                }
                _contexto.Usuarios.Remove(usuario);
                _contexto.SaveChanges();
                return true;
            }
            catch{
                return false;
            }
        }

        public UsuarioApp ObterPorId(int id)
        {
            try
            {
                var usuario = _contexto.Usuarios.FirstOrDefault(p => p.Id == id);
                if(usuario == null)
                {
                    throw new Exception($"Erro ao obter usuário com Id = {id}.");
                }
                return usuario;
            }
            catch(Exception ex)
            {
               throw new Exception( ex.Message) ;
            }
        }

        public UsuarioApp ObterPorEmail(string email)
        {
            try
            {
                var usuario = _contexto.Usuarios.FirstOrDefault(p => p.Email == email);
                if (usuario == null)
                {
                    throw new Exception($"Erro ao obter usuário com email = {email}.");
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<UsuarioApp> ObterTodos()
        {
            try
            {
                return _contexto.Usuarios.ToList();
            }
            catch
            {
                throw new Exception("Erro ao obter Usuários.");
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
