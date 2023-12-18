using System;
using System.Collections.Generic;
using System.Windows;

namespace ObserverPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> people = new List<Person>();

        private WeatherData weatherData = WeatherData.GetWeatherData();

        public MainWindow()
        {
            InitializeComponent();

            Person person = new Person("Steve", "Guttenberg", this.weatherData);
            this.people.Add(person);

            person = new Person("Ted", "Danson", this.weatherData);
            this.people.Add(person);

            person = new Person("Tom", "Selleck", this.weatherData);
            this.people.Add(person);

            this.people.ForEach(p => p.OnTextUpdate += this.PopulateListBox);
            HeatAlert heatAlert = new HeatAlert(this.weatherData);
            this.weatherData.RegisterObserver(heatAlert);

		}

        private void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = this.peopleListBox.SelectedItem as Person;

            if (person != null)
            {
                person.Update();
            }
            else
            {
                MessageBox.Show("Please select a person from the list.");
            }
        }

        private void PopulateListBox()
        {
			this.Dispatcher.Invoke(new Action(delegate () {
		    this.peopleListBox.ItemsSource = null;
			this.peopleListBox.ItemsSource = this.people;
			}));
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.PopulateListBox();
        }

		private void subscribeButton_Click(object sender, RoutedEventArgs e)
		{
			Person person = this.peopleListBox.SelectedItem as Person;
            weatherData.RegisterObserver(person);
		}

		private void unsubscribeButton_Click(object sender, RoutedEventArgs e)
		{
			Person person = this.peopleListBox.SelectedItem as Person;
			weatherData.RemoveObserver(person);
		}
	}
}