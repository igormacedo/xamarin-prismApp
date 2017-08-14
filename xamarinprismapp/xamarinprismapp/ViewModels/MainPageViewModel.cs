using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using xamarinprismapp.Caller;
using xamarinprismapp.Models;

namespace xamarinprismapp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private IPageDialogService _dialogService;

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

        private DelegateCommand _refreshCommand;
        public DelegateCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExeRefreshCommand));

        private void ExeRefreshCommand()
        {
            try
            {
                Tarefa = ApiCaller.GetTarefas();
            }
            catch(Exception ex)
            {
                if(ex.GetBaseException() is System.Net.Http.HttpRequestException)
                {
                    _dialogService.DisplayAlertAsync("Error!", "No internet connection", "ok");
                }
                else
                {
                    _dialogService.DisplayAlertAsync("Error!", "unknown error", "ok");
                    System.Diagnostics.Debug.WriteLine("Exception happened\n" + ex.ToString());
                    System.Diagnostics.Debug.WriteLine("Exception " + ex.GetBaseException().GetType().ToString());
                }
            }
        }

        public MainPageViewModel(IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            //Tarefa = ApiCaller.GetTarefas();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //Tarefa = ApiCaller.GetTarefas();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
