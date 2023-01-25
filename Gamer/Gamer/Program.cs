using System.Threading;

Console.Clear();

Thread clockThread = new Thread(UpdateClock);
clockThread.Start();

Thread clockThread = new Thread(UpdateClock);
clockThread.Start()

static void UpdateClock()
{
	while (true)
	{
		Console.SetCursorPosition(0, 0);
		Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

		Thread.Sleep(1000);
	}
}

static void CreateAlarm()
{
	System.Console.WriteLine("enter the time you wish to set an alarm for as HH:mm e.g. 10:30");
	string alarm = System.Console.readLine();

	while(alarm != DateTime.Now.ToString("HH:mm"));
	{
		Thread.Sleep(5000);
	}
	System.console.beep(800, 200);
}
