using System.Threading;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Drawing;

Console.Clear();

var consoleWriteLock = new object();

Task[] tasks = {
	UpdateClock(),
	GetData(),
	CreateAlarm(),
};

Task.WaitAll(tasks);

void Write(int x, int y, string text)
{
	lock(consoleWriteLock)
	{
		int oldX = Console.CursorLeft, oldY = Console.CursorTop;
		Console.SetCursorPosition(x, y);
		Console.Write(text);
		Console.SetCursorPosition(oldX, oldY);
	}
}

async Task UpdateClock()
{
	while (true)
	{
		Write(0, 0, DateTime.Now.ToString("HH:mm:ss"));
		await Task.Delay(1000);
	}
};


async Task GetData()
{
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    while (true)
	{
		
		var data = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=56.45&lon=9.39&appid=783c89b60e639f20a696fd9285eed4b7");
		var result = JsonSerializer.Deserialize<WeatherData>(data);

        var weather = result.weather[0];

		Write(0, 1, $"{weather.description}, {result.main.temp}, {result.name}");

		await Task.Delay(60 * 1000);
	}
}

async Task CreateAlarm()
{
	Write(0, 2, "enter the time you wish to set an alarm for as HH:mm e.g. 10:30");
	lock (consoleWriteLock) { Console.SetCursorPosition(0, 3); }

	string alarm = System.Console.ReadLine();

	while(alarm != DateTime.Now.ToString("HH:mm"))
	{
		await Task.Delay(1000);
	}

	System.Console.Beep(800, 200);
}

public class WeatherData
{
	public string? name { get; set; }
    public List<Weather>? weather { get; set; }
    public Main? main { get; set; }
	public class Weather
	{
	    public string? description { get; set; }
	}
	public class Main
	{
		public double? temp { get; set; }
	}
}
