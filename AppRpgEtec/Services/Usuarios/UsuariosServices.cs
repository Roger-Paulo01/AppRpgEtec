using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppRpgEtec.Services.Usuarios
{
    public class UsuariosServices : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "http://xyz.somee.com/RpgApi/Usuarios";
        //private const string _apiUrlBase = "http://xyz.azurewebsites.net/Usuarios";

        public UsuariosServices()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(_apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }
        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(_apiUrlBase + urlComplementar, u, string.Empty);
            return u;
        }
    }
}
