using Microsoft.UI.Xaml;
using Windows.ApplicationModel.Background;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BackgroundTaskNET8.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
		this.InitializeComponent();

		foreach (var task in BackgroundTaskRegistration.AllTasks)
		{
			task.Value.Unregister(true);
		}

		var builder = new BackgroundTaskBuilder
		{
			Name = "TestTask",
			TaskEntryPoint = "BackgroundTask.TestTask"
		};
		builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
		builder.Register();
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

