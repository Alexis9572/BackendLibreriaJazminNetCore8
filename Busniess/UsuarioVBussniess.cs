using AutoMapper;
using IBusniess;
using IRepository;
using Repository;
using RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilSecurity;

namespace Busniess
{
    public class UsuarioVBussniess : IUsuarioVBussniess
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IUsuarioBusniess _usuarioBussniess;
        private readonly IPersonaBusniess _personaBussniess;
        private readonly IRolBusniess _rolBussniess;
        private readonly ITipoDocumentoBusniess _tipoDocumentoBussniess;
        private readonly UtilEncriptarDesencriptar _cripto;
        private readonly IMapper _mapper;
        public UsuarioVBussniess(IMapper mapper)
        {
            _usuarioBussniess = new UsuarioBusniess(mapper);
            _personaBussniess = new PersonaBusniess (mapper);
            _rolBussniess = new RolBusniess(mapper);
            _tipoDocumentoBussniess = new TipoDocumentoBusniess(mapper);
            _cripto = new UtilEncriptarDesencriptar();
            _mapper = mapper;
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        public UsuarioVResponse Create(UsuarioVRequest entity)
        {
            PersonaResponse personaResponse = new PersonaResponse();
            UsuarioResponse usuarioResponse = new UsuarioResponse();
            UsuarioVResponse usuarioVResponse = new UsuarioVResponse();
            //Creacion de persona
           

            if (entity.Documento=="DNI")
            {

                PersonaRequest personaRequest = _mapper.Map<PersonaRequest>(entity.persona);
                personaRequest.Idtipodocumento = 1;
                personaResponse = _personaBussniess.Create(personaRequest);
                if (personaResponse == null)
                {
                    personaResponse.Message = "Nose Pudo Crear la Persona";
                    return usuarioVResponse;
                }
                usuarioVResponse = _mapper.Map<UsuarioVResponse>(personaResponse);

                UsuarioRequest usuarioRequest = _mapper.Map<UsuarioRequest>(entity);
                usuarioRequest.RolId = 2;
                usuarioRequest.Estado = "ACTIVO";
                string claveEncriptada = _cripto.AES_encriptar(entity.Contrasenia);
                usuarioRequest.Contrasenia = claveEncriptada;
                usuarioRequest.PersonaId = personaResponse.Id;
                usuarioResponse = _usuarioBussniess.Create(usuarioRequest);
                usuarioVResponse = _mapper.Map<UsuarioVResponse>(usuarioResponse);
                return usuarioVResponse;
            }
            if (entity.Documento == "CE")
            {
                PersonaRequest personaRequest = _mapper.Map<PersonaRequest>(entity);
                personaRequest.Idtipodocumento = 2;
                personaResponse = _personaBussniess.Create(personaRequest);
                if (personaResponse == null)
                {
                    personaResponse.Message = "Nose Pudo Crear la Persona";
                    return usuarioVResponse;
                }

                usuarioVResponse = _mapper.Map<UsuarioVResponse>(personaResponse);

                UsuarioRequest usuarioRequest = _mapper.Map<UsuarioRequest>(entity);
                usuarioRequest.RolId = 1;
                personaResponse.Id = usuarioRequest.PersonaId;
                usuarioRequest.Estado = "ACTIVO";
                string claveEncriptada = _cripto.AES_encriptar(entity.Contrasenia);
                usuarioRequest.Contrasenia = claveEncriptada;
                usuarioResponse = _usuarioBussniess.Create(usuarioRequest);

                usuarioVResponse = _mapper.Map<UsuarioVResponse>(usuarioResponse.persona);
                usuarioVResponse = _mapper.Map<UsuarioVResponse>(usuarioResponse);
    
            

                return usuarioVResponse;
            }


            return usuarioVResponse;
        }

        public List<UsuarioVResponse> CreateMultiple(List<UsuarioVRequest> lista)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteMultipleItems(List<UsuarioVRequest> lista)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<UsuarioVResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioVResponse GetById(int id)
        {
            //Obtengo el id del sesion store

            //Busco en la base de datos y me devuelve la lista del usuario

            //Despues de obtener la vista con el persona_id busco la lista y me devuelve la lista de su persona 

            //Despues de obtener la vista con el rol_Id busco la lista y me devuelve la lista de su rol 

            //Despues lo alamaceno en UsuarioVResponse
            

            throw new NotImplementedException();
        }

        public UsuarioVResponse Update(UsuarioVRequest entity)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioVResponse> UpdateMultiple(List<UsuarioVRequest> lista)
        {
            throw new NotImplementedException();
        }
    }
}
