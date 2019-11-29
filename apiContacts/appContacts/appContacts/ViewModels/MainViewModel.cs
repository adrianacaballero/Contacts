using appContacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace appContacts.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public List<Contacts> ListContacts { get; set; }
        #endregion

        #region ViewModels
        public ContactsViewModel contactsViewModel { get; set; }      //(Ctrl punto se tiene que agregar una clase dentro de ViewModels llamada PhoneBookViewModel)
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            contactsViewModel = new ContactsViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }
            return (instance);
        }
        #endregion

    }
}
