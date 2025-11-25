using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RequestResponse
{
    public class UsuarioResponse
    {
        
        public string NombreRol { get; set; } = null!;

  
        public int RolId { get; set; }

        public int Id { get; set; }


        public int PersonaId { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Contrasenia { get; set; } = null!; 

        public PersonaRequest? persona { get; set; }
        public string Correo { get; set; } = null!;
    }
}
