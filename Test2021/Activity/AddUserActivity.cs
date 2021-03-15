using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Test2021Library.ViewModel;
namespace Test2021.Activity
{
    [MvxActivityPresentation]
    [Activity(Label = "AddUserActivity")]
    public class AddUserActivity : MvxActivity<NewUserViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_user);
        }

    }
}
