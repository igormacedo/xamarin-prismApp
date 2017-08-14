using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using xamarinprismapp.Models;

namespace xamarinprismapp.Caller
{
    public static class ApiCaller
    {
        private static Uri BASE_ADDRESS = new Uri("http://igormacedo.pythonanywhere.com/");

        public static ObservableCollection<Tarefa> GetTarefas()
        {
            var result = new ObservableCollection<Models.Tarefa>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = BASE_ADDRESS;
                HttpResponseMessage response = client.GetAsync("api/todos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    TarefaHolder th = JsonConvert.DeserializeObject<TarefaHolder>(json);
                    return result = th.TarefaList;
                }
                else
                {
                    return result = new ObservableCollection<Tarefa>();
                }
            }
        }
    }
}
