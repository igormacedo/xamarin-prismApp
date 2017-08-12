using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using xamarinprismapp.Helpers;
using xamarinprismapp.Models;

namespace xamarinprismapp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<Tarefa> _tarefa;
        public ObservableCollection<Tarefa> Tarefa
        {
            get { return _tarefa; }
            set { SetProperty(ref _tarefa, value); }
        }

        public MainPageViewModel()
        {
            Tarefa = ApiCaller.GetTarefas();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
