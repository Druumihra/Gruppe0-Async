using System.Threading;

var consoleWriteLock = new object();

Console.Clear();

Thread clockThread = new Thread(UpdateClock);
clockThread.Start();

Thread alarmThread = new Thread(CreateAlarm);
alarmThread.Start();

void UpdateClock()
{
	while (true)
	{
		lock(consoleWriteLock)
		{
			Console.SetCursorPosition(0, 0);
			Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
			Console.SetCursorPosition(0, 3);
		}

		Thread.Sleep(1000);
	}
}

void CreateAlarm()
{
	lock(consoleWriteLock)
	{
		Console.SetCursorPosition(0, 2);
		System.Console.WriteLine("enter the time you wish to set an alarm for as HH.mm e.g. 10.30");
	}

	string alarm = System.Console.ReadLine();

	while(alarm != DateTime.Now.ToString("HH:mm"))
	{
		Thread.Sleep(5000);
	}

	System.Console.Beep(800, 200);
}
