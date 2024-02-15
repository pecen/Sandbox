using MetroHamburgerMenu.Core.MVVM;
using System.Diagnostics;
using System.IO.Enumeration;

namespace MetroHamburgerMenu.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Commands

        public DelegateCommand LaunchGitHubSiteCommand { get; set; }
        public DelegateCommand DeployCupCakesCommand { get; set; }

        #endregion

        public MainWindowViewModel()
        {
            Title = "Hamburger Menu Test";

            LaunchGitHubSiteCommand = new DelegateCommand(LaunchGitHubSite);
            DeployCupCakesCommand = new DelegateCommand(GetPasta);
        }

        private void GetPasta()
        {
            // In .NetFx 4.8.1 and earlier you could use Process.Start("https://www.bbcgoodfood.com/recipes/cupcakes") but from 
            // .Net 6.0 you need to use the following command to be able to set UseShellExecute
            Process.Start(new ProcessStartInfo { FileName = @"https://www.bbcgoodfood.com/recipes/cupcakes", UseShellExecute = true });
        }

        private void LaunchGitHubSite()
        {
            Process.Start(new ProcessStartInfo { FileName = "https://www.github.com", UseShellExecute = true });
        }
    }
}
