using System.Threading;

Console.Clear();

Thread clockThread = new Thread(UpdateClock);
clockThread.Start();

static void UpdateClock()
{
	while (true)
	{
		Console.SetCursorPosition(0, 0);
		Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

		Thread.Sleep(1000);
	}
}
