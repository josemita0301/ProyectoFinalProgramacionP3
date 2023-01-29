using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Views;

public partial class DogPage : ContentPage
{
	public DogPage()
	{
		InitializeComponent();
        LoadData();
        BindingContext = this;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        List<Dog> dogs = App.BetterHomeRepo.GetAllDogs();
        dogsList.ItemsSource = dogs;
    }

    async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Dog dog = new Dog();
        dog = dogsList.SelectedItem as Dog;

        await Shell.Current.GoToAsync(nameof(UploadDogPage), true, new Dictionary<string, object>()
        {
            ["Item"] = dog
        });
    }

    async void OnItemAdded(object sender, EventArgs e)
    {
            await Shell.Current.GoToAsync(nameof(UploadDogPage), true, new Dictionary<string, object>()
            {
                ["Item"] = new Dog()
            });
    }
}