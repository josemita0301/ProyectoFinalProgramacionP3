using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Views;

[QueryProperty("Item", "Item")]
public partial class RegisterPage : ContentPage
{
    
    public User Item
    {
        get => BindingContext as User;
        set => BindingContext = value;
    }
    public RegisterPage()
	{
        if (App.loggedUser != null)
            Item = App.loggedUser;

		InitializeComponent();
	}

    async void RegisterClick(object sender, EventArgs e)
    {
        GetImageRoute();
        App.BetterHomeRepo.AddNewUser(Item);

        if (App.loggedUser == null)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage), true, new Dictionary<string, object>()
            {
                ["Item"] = Item
            });
        }
        else
        {
            await Shell.Current.GoToAsync(nameof(DogPage));
        }
        
    }

    private void GetImageRoute()
    {
        if (rb1.IsChecked)
        {
            Item.imageRoute = "user1.png";
        }
        if (rb2.IsChecked)
        {
            Item.imageRoute = "user2.png";
        }
        if (rb3.IsChecked)
        {
            Item.imageRoute = "user3.png";
        }
        if (rb4.IsChecked)
        {
            Item.imageRoute = "user4.png";
        }
        if (rb5.IsChecked)
        {
            Item.imageRoute = "user5.png";
        }
        if (rb6.IsChecked)
        {
            Item.imageRoute = "user6.png";
        }
    }
}