using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Views;

[QueryProperty("Item", "Item")]
public partial class UploadDogPage : ContentPage
{
    public Dog Item
    {
        get => BindingContext as Dog;
        set => BindingContext = value;
    }

    public UploadDogPage()
	{
		InitializeComponent();
	}

    public void UploadDogClicked(object sender, EventArgs e)
    {
        App.BetterHomeRepo.AddNewDog(Item);
        Shell.Current.GoToAsync("..");
    }

    public void DeleteDogClicked(object sender, EventArgs e)
    {
        App.BetterHomeRepo.DeleteDog(Item);
        Shell.Current.GoToAsync("..");
    }
}