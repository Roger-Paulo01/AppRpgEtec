using AppRpgEtec.Models;
using AppRpgEtec.Services.Armas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppRpgEtec.ViewModels.Armas
{
    public class ListagemArmaViewModel : BaseViewModel
    {
        private ArmasService pService;
        public ObservableCollection<Arma> Armas { get; set; }
        public ListagemArmaViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService = new ArmasService(token);
            Armas = new ObservableCollection<Arma>();

            _ = ObterArmas();
        }

        public async Task ObterArmas()
        {
            try
            {
                Armas = await pService.GetArmasAsync();
                OnPropertyChanged(nameof(Armas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
