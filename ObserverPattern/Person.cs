using ObserverPattern.Interfaces;
using System;

namespace ObserverPattern
{
    public class Person : IObserver
    {
        private string firstName;

        private double humidity;

        private string lastName;

        private double pressure;

        private double temperature;

        private WeatherData weatherData;

        public Person(string firstName, string lastName, WeatherData weatherData)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.weatherData = weatherData;
        }

        public Action OnTextUpdate { get; set; }

        public void GetWeather()
        {
           
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName}: Temp: {this.temperature}, Humidity: {this.humidity}, Pressure: {this.pressure}";
        }

		public void Update()
		{
			this.temperature = this.weatherData.Temperature;
			this.humidity = this.weatherData.Humidity;
			this.pressure = this.weatherData.Pressure;

			this.OnTextUpdate();
		}
	}
}