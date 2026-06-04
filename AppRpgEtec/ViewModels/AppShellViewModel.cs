using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppRpgEtec.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private UsuarioService uService;

        private static string conexaoAzureStorage = ""; //colocar chave azure nesta linha
        private static string container = "arquivos";
        public AppShellViewModel()
            {
                string token = Preferences.Get("UsuarioToken", string.Empty);
                uService = new UsuarioService(token);

                CarregarUsuarioAzure();
            }

        private byte[] foto;
        public byte[] Foto
        {
            get => foto;
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }

        public async void CarregarUsuarioAzure()
        {
            try
            {
                int usuarioId = Preferences.Get("UsuarioId", 0);
                string filename = $"{usuarioId}.jpg";
                var blobClient = new BlobClient(conexaoAzureStorage, container, filename);

                if (blobClient.Exists())
                {
                    Byte[] fileBytes;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        blobClient.OpenRead().CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    Foto = fileBytes;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException.Message, "Ok");
            }
        }

        public async void SalvarImagem()
        {
            try
            {
                Usuario u = new Usuario();
                u.Foto = foto;
                u.Id = Preferences.Get("UsuarioId", 0);

                if (await uService.PutFotoUsuarioAsync(u) != 0)
                {
                    await Application.Current.MainPage.DisplayAlert("Mensgaem", "Dados salvos com sucesso!", "Ok");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else { throw new Exception("Erro ao tentar atualizar imagem"); }

            }
            catch (Exception ex)
            {

                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }



    }
}
