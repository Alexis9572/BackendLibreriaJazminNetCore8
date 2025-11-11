using DBLibreria.DBLibreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class UsuarioVRequest
    {
        public string NombreRol { get; set; } = null!;
        public int RolId { get; set; }
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public Persona? persona { get; set; }
    }
}
