using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Net.Http.Headers;



Console.Clear();

Thread clockThread = new Thread(UpdateClock);
clockThread.Start();
Thread WeatherThread = new Thread(GetData);
WeatherThread.Start();
static void UpdateClock()
{
	while (true)
	{
		Console.SetCursorPosition(0, 0);
		Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

		Thread.Sleep(1000);
	}
};


static async void GetData()
{
    using HttpClient client = new();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    while (true)
	{
	var json = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=56.45&lon=9.39&appid=783c89b60e639f20a696fd9285eed4b7");
	Console.WriteLine($"{json}");
	Thread.Sleep(60*1000);
	}
}
