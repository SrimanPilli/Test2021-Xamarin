using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Test2021Library.Helper;

namespace Test2021Library.ViewModel
{
    public class UserViewModel: BaseViewModel
    {
        private readonly IUserService userService;
        public MvxObservableCollection<NewUserViewModel> Users { get; set; }
        public UserViewModel()
        {
            userService = Mvx.IoCProvider.Resolve<IUserService>();
            Users = new MvxObservableCollection<NewUserViewModel>();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            Users.Clear();
            var usersList = userService.GetAllUsers();
            foreach (var item in usersList)
            {
                NewUserViewModel userListViewModel = new NewUserViewModel()
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Password = item.Password
                };
                Users.Add(userListViewModel);

            }
        }

        public IMvxCommand AddUserClick => new MvxCommand(AddUserClickCommand);

        private async void AddUserClickCommand()
        {
            await Mvx.IoCProvider.Resolve<IMvxNavigationService>().Navigate(new NewUserViewModel());
        }
    }
}
