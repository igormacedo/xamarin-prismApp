using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xamarinprismapp.Models
{
    [JsonObject]
    public class TarefaHolder
    {
        private ObservableCollection<Tarefa> _tarefaList;

        [JsonProperty(PropertyName = "tasks")]
        public ObservableCollection<Tarefa> TarefaList
        {
            get { return _tarefaList; }
            set { _tarefaList = value; }
        }
    }

    [JsonObject]
    public class Tarefa
    {
        [JsonProperty(PropertyName = "tarefaID")]
        public int TarefaId { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "finalizado")]
        public bool Finalizado { get; set; }
    }
}
