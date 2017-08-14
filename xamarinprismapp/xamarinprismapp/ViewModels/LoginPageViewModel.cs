using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xamarinprismapp.ViewModels
{
    public class LoginPageViewModel : BindableBase, INavigatingAware
    {
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;

        string usernameOut = null, passwordOut = null;

        private string _username = null;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = null;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private DelegateCommand _goToSignUpPageCommand;     
        public DelegateCommand GoToSignUpPageCommand =>
            _goToSignUpPageCommand ?? (_goToSignUpPageCommand = new DelegateCommand(GoToSignUpPage));

        private void GoToSignUpPage()
        {
            Username = "Going out";
            _navigationService.NavigateAsync("SignUpPage");
        }

        private DelegateCommand _loginBtnCommand;
        public DelegateCommand LoginBtnCommand =>
            _loginBtnCommand ?? (_loginBtnCommand = new DelegateCommand(LoginBtn)
                                                    .ObservesProperty(()=>Username)
                                                    .ObservesProperty(()=>Password));

        private async void LoginBtn()
        {
            if(_username == null && _password == null)
            {
                await _dialogService.DisplayAlertAsync("Wow!", "you know this stuff, " + _username, "I'm a hacker");
                await _navigationService.NavigateAsync(new Uri("/MainPage", UriKind.Absolute));
            }
            else
            {
                await _dialogService.DisplayAlertAsync("Error!", "Wrong username, try: " + usernameOut + " & " + passwordOut, "I'm a hacker");
            }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //_dialogService.DisplayAlertAsync("Navigated to","balbal", "ok");

            if (parameters.ContainsKey("Name") && parameters.ContainsKey("Password"))
            {
                usernameOut = parameters["Name"].ToString();
                passwordOut = parameters["Password"].ToString();
                Username = parameters["Name"].ToString();
            }
        }
    }
}
