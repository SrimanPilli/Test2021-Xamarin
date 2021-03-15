using System;
using System.Collections.Generic;
using System.Text;

namespace Test2021Library.ViewModel
{
    public class UserListViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;
        private string _firstName;
        private string _lastName;

        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName == value)
                    return;

                _userName = value;
                
                RaisePropertyChanged(nameof(_userName));
            }
        }       
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;

                _password = value;
                RaisePropertyChanged(nameof(_password));
            }
        }
   
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;
                RaisePropertyChanged(nameof(_firstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;
                RaisePropertyChanged(nameof(_lastName));
            }
        }
    }
}
