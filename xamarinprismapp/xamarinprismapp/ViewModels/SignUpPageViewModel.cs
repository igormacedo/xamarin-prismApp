using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace xamarinprismapp.ViewModels
{
    public class SignUpPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;

        private string _name = null;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _phone = null;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _email = null;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _password = null;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private DelegateCommand _cancelBtnCommand;
        public DelegateCommand CancelBtnCommand =>
            _cancelBtnCommand ?? (_cancelBtnCommand = new DelegateCommand(CancelBtn));

        private void CancelBtn()
        {
            _navigationService.GoBackAsync();
        }

        private DelegateCommand _submitBtnCommand;
        public DelegateCommand SubmitBtnCommand =>
            _submitBtnCommand ?? (_submitBtnCommand = new DelegateCommand(SubmitBtn)
                                                          .ObservesProperty(() => Name)
                                                          .ObservesProperty(() => Phone)
                                                          .ObservesProperty(() => Email)
                                                          .ObservesProperty(() => Password));

        private async void SubmitBtn()
        {
            NavigationParameters p = new NavigationParameters
            {
                { "Name", _name },
                { "Phone", _phone },
                { "Email", _email },
                { "Password", _password }
            };

            await _dialogService.DisplayAlertAsync("Warning!", "You are being watched " + _name, "I don't mind the Big Brother");
            await _navigationService.GoBackAsync(p);
        }

        public SignUpPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }
    }
}
