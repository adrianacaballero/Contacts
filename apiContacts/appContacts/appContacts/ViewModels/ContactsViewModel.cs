namespace appContacts.ViewModels
{
    using appContacts.Models;
    using appContacts.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ContactsViewModel : BaseViewModel
    {
        #region Attributes
        private ApiService apiService;
        private ObservableCollection<Contacts> contacts;
        #endregion

        #region Properties
        public ObservableCollection<Contacts> Contacts
        {
            get { return this.contacts; }
            set { SetValue(ref this.contacts, value); }
        }
        #endregion

        #region Constructor
        public ContactsViewModel()
        {
          this.apiService = new ApiService();
          this.LoadContacts();
        }

        #endregion

        #region Methods
        private async void LoadContacts()
        {
            var connection = await apiService.CheckConnection();
            if(!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Internet Error Connection",
                    connection.Message,
                    "Accept"
                   );
                return;
            }

            var response = await apiService.GetList<Contacts>(
            "http://localhost:49259/",
            "api/",
            "Contacts"
            ); 
            if (!response.IsSuccess)
            {
             await Application.Current.MainPage.DisplayAlert(
            "Contacts Service Error",
            response.Message,
             "Accept"
              );
                return;
            }
            MainViewModel main = MainViewModel.GetInstance();
            main.ListContacts = (List<Contacts>)response.Result;

        }

        #endregion
    }

}

