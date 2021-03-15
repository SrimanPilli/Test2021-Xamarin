using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System.Text.RegularExpressions;
using Test2021Library.Helper;
using Test2021Library.Models;

namespace Test2021Library.ViewModel
{
    public class NewUserViewModel : BaseViewModel
    {
        #region Fields

        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private readonly IUserService userService;

        #endregion Fields

        #region Properties
        public NewUserViewModel()
        {
            this.userService = Mvx.IoCProvider.Resolve<IUserService>();
        }


        public string UserName
        {
            get => userName;
            set
            {
                if (userName == value)
                    return;

                userName = value;
                RaisePropertyChanged(nameof(userName));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (password == value)
                    return;

                password = value;
                RaisePropertyChanged(nameof(password));
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName == value)
                    return;

                firstName = value;
                RaisePropertyChanged(nameof(firstName));
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName == value)
                    return;

                lastName = value;
                RaisePropertyChanged(nameof(lastName));
            }
        }

        #endregion Properties

        #region Button Command & Private Method
        // When user clicks AddUser button
        public IMvxCommand AddUserClick => new MvxCommand(AddUserClickCommand);

        private async void AddUserClickCommand()
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                Regex rgx = new Regex(@"(.+)\1");
                if (!rgx.IsMatch(Password) && Password.Length >= 5 && Password.Length <= 12)
                {
                    UsersModel users = new UsersModel()
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        UserName = this.UserName,
                        Password = this.Password
                    };

                    // Adding new user
                    userService.InsertUser(users);

                    await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Close(this);
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync("Password strength is not good. Please choose another password.");
                }
            }
            else
            {
                await UserDialogs.Instance.AlertAsync("Please enter values in all the fields.");
            }
        }

        #endregion Button Command & Private Method
    }
}
