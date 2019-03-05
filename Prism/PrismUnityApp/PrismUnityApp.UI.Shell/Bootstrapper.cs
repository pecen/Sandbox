using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using PrismUnityApp.Module;
using PrismUnityApp.Module.Views;
using PrismUnityApp.UI.Shell.Enums;
using PrismUnityApp.UI.Shell.Views;
using PrismUnityApp.Utilities.Extensions;
using System.Windows;

namespace PrismUnityApp.UI.Shell
{
	class Bootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void InitializeShell()
		{
			Application.Current.MainWindow.Show();

			ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
			moduleCatalog.AddModule(typeof(PrismUnityAppModule));
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			//Container.RegisterTypeForNavigation<PersonViewA>(EnumExtensions.GetEnumDescription(ViewNames.PersonViewA));
			//Container.RegisterTypeForNavigation<PersonViewB>(EnumExtensions.GetEnumDescription(ViewNames.PersonViewB));
		}
	}
}
