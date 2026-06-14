using System;
using System.Collections.Generic;
using System.Text;
using AppRpgEtec.Models;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Disputas
{
    public class DisputaService : Request
    {
        private readonly Request _request;
        private string _token;

        private const string _apiUrlBase = "https://luizsilva12.somee.com/RpgApi/Disputa";
        public DisputaService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Disputa> PostDisputaComArmaAsync(Disputa d)
        {
            string urlComplementar = "/Arma";
            return await _request.PostAsync(_apiUrlBase + urlComplementar, d, _token);
        }
        public async Task<Disputa> PostDisputaComHabilidadeAsync(Disputa d)
        {
            string urlComplementar = "/Arma";
            return await _request.PostAsync(_apiUrlBase + urlComplementar, d, _token);
        }
        public async Task<Disputa> PostDisputaGeralAsync(Disputa d)
        {
            string urlComplementar = "/DisputaEmGrupo";
            return await _request.PostAsync(_apiUrlBase + urlComplementar, d, _token);
        }
    }
}

