using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace FilmRatingsApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(typeof(Views.HomePage));
        }
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // Si l'utilisateur clique sur la roue dentée (Settings)
                ContentFrame.Navigate(typeof(Views.SettingsPage));
            }
            else
            {
                // Récupère l'item sélectionné
                var selectedItem = args.SelectedItem as NavigationViewItem;
                if (selectedItem != null)
                {
                    // On regarde le "Tag" pour savoir quelle page charger
                    string pageTag = selectedItem.Tag.ToString();

                    // On fait le lien entre le Tag et le type de la Page
                    switch (pageTag)
                    {
                        case "HomePage":
                            ContentFrame.Navigate(typeof(Views.HomePage));
                            sender.Header = "Home";
                            break;
                        case "UtilisateurPage":
                            ContentFrame.Navigate(typeof(Views.UtilisateurPage));
                            sender.Header = "Utilisateur";
                            break;
                        case "FilmPage":
                            ContentFrame.Navigate(typeof(Views.FilmPage));
                            sender.Header = "Films";
                            break;
                        case "NotesPage":
                            ContentFrame.Navigate(typeof(Views.NotesPage));
                            sender.Header = "Notes";
                            break;
                    }
                }
            }
        }
    }
}
