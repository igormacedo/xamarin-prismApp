using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamarinprismapp.Models;

namespace xamarinprismapp.Helpers
{
    public static class ApiCaller
    {
        private static Uri BASE_ADDRESS = new Uri("http://gsuite.azurewebsites.net/");

        public static ObservableCollection<Tarefa> GetTarefas()
        {
            var result = new ObservableCollection<Models.Tarefa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = BASE_ADDRESS;
                HttpResponseMessage response = client.GetAsync("api/tarefasservice").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    return result = JsonConvert.DeserializeObject<ObservableCollection<Tarefa>>(json);

                }

                else
                {
                    return result = new ObservableCollection<Models.Tarefa>();
                }
            }
        }
    }
}
