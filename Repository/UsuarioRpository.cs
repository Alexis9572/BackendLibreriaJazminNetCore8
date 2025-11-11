using DBLibreria;
using DBLibreria.DBLibreria;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : CRUDRepository<Usuario>, IUsuarioRepository
    {
        public Usuario obtenerUsuario(string usuario)
        {
            Usuario? roles = db.Usuarios.Where(x => x.Usuario1 == usuario).FirstOrDefault();
            return roles;
        }

        public Perfil perfil(string nombre)
        {
            Perfil? roles = db.Perfils.Where(x => x.Usuario1 == nombre).FirstOrDefault();
            return roles;
        }
    }
}
