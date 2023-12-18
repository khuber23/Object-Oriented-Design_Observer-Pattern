using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ObserverPattern
{
	public class HeatAlert : IObserver
	{
		private WeatherData weatherData;
		public HeatAlert(WeatherData weatherData)
		{
			this.weatherData = weatherData;
		}
		public void Update()
		{
			if(weatherData.HeatIndex == 6)
			{
				MessageBox.Show("Weather is Too Hot");
			}
		}
	}
}
