using ProyectoFinalProgramacion.Data;
using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Views;

[QueryProperty("Item", "Item")]
public partial class LoginPage : ContentPage
{
    public User Item
    {
        get => BindingContext as User;
        set => BindingContext = value;
    }
    public LoginPage()
	{
		InitializeComponent();
	}

    async void LoginButton(object sender, EventArgs e)
    {
        List<User> validarUsuario = App.BetterHomeRepo.GetAllUsers();

        foreach (User usuario in validarUsuario)
        {
            if((usuario.UserName ==  UsernameField.Text) && (usuario.Password == PasswordField.Text))
            {
                App.loggedUser = usuario;

                await Shell.Current.GoToAsync(nameof(DogPage), true, new Dictionary<string, object>()
                {
                    ["Item"] = Item
                });
            }   
        }
        
    }

    async void RegisterButton(object sender, EventArgs e)
    {
        User user = new User();

        await Shell.Current.GoToAsync(nameof(RegisterPage), true, new Dictionary<string, object>()
        {
            ["Item"] = user
        });
    }
}