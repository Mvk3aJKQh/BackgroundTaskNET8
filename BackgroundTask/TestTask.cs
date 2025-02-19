using System.Diagnostics;
using Windows.ApplicationModel.Background;

namespace BackgroundTask
{
	public sealed class TestTask : IBackgroundTask
	{
		public void Run(IBackgroundTaskInstance taskInstance)
		{
			Debug.WriteLine("Background " + taskInstance.Task.Name + " Starting...");
		}
	}
}
