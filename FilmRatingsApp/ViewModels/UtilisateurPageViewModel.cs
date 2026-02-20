using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
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
        public UtilisateurPageViewModel() 
        {
            BtnSearchUtilisateurCommand = new RelayCommand(RechercheUtilisateur);

        }

        private IService wSService;

        public IService WSService
        {
            get { return wSService; }
            set { wSService = value; }
        }


        private string searchMail;

        public string SearchMail
        {
            get { return searchMail; }
            set { SetProperty(ref searchMail, value); }
        }

        public void RechercheUtilisateur()
        {
            Utilisateur utilisateur = await WSService.GetUtilisateurByEmailAsync(SearchMail); 
        }

    }
}
