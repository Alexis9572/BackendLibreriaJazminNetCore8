using DBLibreria.DBLibreria;
using RequestResponseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestResponse
{
    public class UsuarioVResponse
    {
        public int RolId { get; set; }
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public LoginResponse? LoginResponse { get; set; }  = null; 

    }
}
