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

        public int RolId { get; set; }
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Documento { get; set; } = null!;
       
        public PersonaRequest? persona { get; set; }
    }
}
