using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using HelloWorld.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.ComponentModel;

namespace HelloWorld.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Creature_Monster_Treasure _data;
        public string str {get; set;}
        public Creature_Monster_Treasure data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommand { get; set; }

        public MainPageViewModel()
        {
            str = "...Or use the searchbar to input a name.";
            SearchCommand = new Command(async (searchString) =>
            {
               await GetData($"https://botw-compendium.herokuapp.com/api/v2/entry/{searchString}");
            });
        }

        public async Task GetData(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                str = "...Or use the searchbar to input a name.";
                var jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Creature_Monster_Treasure>(jsonResult);
                data = result;
            }
            else
            {
                str = "No results. Try another name.";
                data = new Creature_Monster_Treasure();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
