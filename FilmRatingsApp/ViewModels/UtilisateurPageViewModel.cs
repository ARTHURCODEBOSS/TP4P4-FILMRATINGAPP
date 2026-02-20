using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.ViewModels
{
    public class UtilisateurPageViewModel : ObservableObject
    {
        public IRelayCommand BtnSearchUtilisateurCommand { get; }
        public IRelayCommand BtnModifyUtilisateurCommand { get; }
        public IRelayCommand BtnClearUtilisateurCommand { get; }
        public IRelayCommand BtnAddUtilisateurCommand { get; }


        public UtilisateurPageViewModel()
        {
            BtnSearchUtilisateurCommand = new RelayCommand(RechercheUtilisateur);
            BtnModifyUtilisateurCommand = new RelayCommand(ModifierUtilisateur);
            BtnClearUtilisateurCommand = new RelayCommand(ClearUtilisateur);
            BtnAddUtilisateurCommand = new RelayCommand(AjouterUtilisateur);
            WSService = new WSService();
        }

        private IService wSService;

        public IService WSService
        {
            get { return wSService; }
            set { wSService = value; }
        }

        private Utilisateur utilisateurSearch;

        public Utilisateur UtilisateurSearch
        {
            get { return utilisateurSearch; }
            set { SetProperty(ref utilisateurSearch, value); }
        }


        private string searchMail;

        public string SearchMail
        {
            get { return searchMail; }
            set { SetProperty(ref searchMail, value); }
        }

        public async void RechercheUtilisateur()
        {
            Utilisateur utilisateur = await WSService.GetUtilisateurByEmailAsync(SearchMail);

            if (utilisateur != null)
            {
                UtilisateurSearch = utilisateur;

            }
            else
            {
                SearchMail = "Utilisateur non trouvé";
            }
        }

        public async void ModifierUtilisateur()
        {
            bool test = await WSService.PutUtilisateurAsync(UtilisateurSearch);
            if (test)
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Information",
                    Content = "Utilisateur modifié !",
                    CloseButtonText = "Ok",
                    // C'EST ICI QUE CA SERT :
                    XamlRoot = App.MainRoot.XamlRoot
                };

                await dialog.ShowAsync();
            }
            else
            {
                SearchMail = "Erreur lors de la modification de l'utilisateur";
            }
        }

        public void ClearUtilisateur()
        {
            SearchMail = string.Empty;
            UtilisateurSearch = null;

        }

        public async void AjouterUtilisateur()
        {
               Utilisateur user = await WSService.PostUtilisateurAsync(UtilisateurSearch);
            if (user != null)
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Information",
                    Content = "Utilisateur ajouté !",
                    CloseButtonText = "Ok",
                    XamlRoot = App.MainRoot.XamlRoot
                };
                await dialog.ShowAsync();
            }
            else
            {
                SearchMail = "Erreur lors de l'ajout de l'utilisateur";
            }
        }
    }
}
