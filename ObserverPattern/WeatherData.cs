using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Timers;

namespace ObserverPattern
{
    public class WeatherData : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        private static WeatherData weatherData = new WeatherData();

        private int heatIndex;

        private double humidity;

        private double pressure;

        private Random random = new Random();

        private double temperature;

        private WeatherData()
        {
            this.StartTimer();
        }

        public int HeatIndex => this.heatIndex;

        public double Humidity => Math.Round(this.humidity, 2);

        public double Pressure => Math.Round(this.pressure, 2);

        public double Temperature => Math.Round(this.temperature, 2);

        public static WeatherData GetWeatherData()
        {
            return weatherData;
        }

		public void NotifyObservers()
		{
            foreach (var observer in observers)
            {
                observer.Update();
            }
            // Another way 
            //for(var i = 0; i< observers.Count; i++) { observers[i].Update(); }
        }

		public void RegisterObserver(IObserver o)
		{
            observers.Add(o);
		}

		public void RemoveObserver(IObserver o)
		{
            observers.Remove(o);
		}

		public void StartTimer()
        {
            Timer timer = new Timer(2000);

            timer.Start();
            timer.Elapsed += this.MeaurementsChanged;
        }

        private void MeaurementsChanged(object sender, ElapsedEventArgs e)
        {
            this.temperature = random.NextDouble() * (65 - 63) + 63;
            this.humidity = random.NextDouble() * (30 - 26) + 26;
            this.pressure = random.NextDouble() * (10 - 1) + 1;
            this.heatIndex++;
            this.NotifyObservers();
        }
    }
}