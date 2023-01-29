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
        GetImage();
        App.BetterHomeRepo.AddNewDog(Item);
        Shell.Current.GoToAsync("..");
    }

    public void DeleteDogClicked(object sender, EventArgs e)
    {

        App.BetterHomeRepo.DeleteDog(Item);
        Shell.Current.GoToAsync("..");
    }

    private void GetImage()
    {
        if (rb1.IsChecked)
        {
            Item.imageRoute = "dog1.webp";
        }
        if (rb2.IsChecked)
        {
            Item.imageRoute = "dog2.webp";
        }
        if (rb3.IsChecked)
        {
            Item.imageRoute = "dog3.webp";
        }
        if (rb4.IsChecked)
        {
            Item.imageRoute = "dog4.webp";
        }
        if (rb5.IsChecked)
        {
            Item.imageRoute = "dog5.webp";
        }
        if (rb6.IsChecked)
        {
            Item.imageRoute = "dog6.webp";
        }
    }
}