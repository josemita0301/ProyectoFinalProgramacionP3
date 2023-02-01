using Newtonsoft.Json;
using ProyectoFinalProgramacion.Models;
using ProyectoFinalProgramacion.API;
using System.Net;

namespace ProyectoFinalProgramacion.Views;

[QueryProperty("Item", "Item")]
public partial class UploadDogPage : ContentPage
{
    List <Dog> dogList;
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
        //CargarApi();
        Item.CreationDate = DateTime.Parse(fuente.Text);
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

    //Implementaci�n de la API
    public void CargarApi()
    {
        WebRequest request = WebRequest.Create("https://dog.ceo/api/breed/"+ cadena + "/images/random");
        //request.Headers.Add("X-TheySaidSo-Api-Secret", "YOUR API KEY HERE");
������� WebResponse response = request.GetResponse();
        var client = new HttpClient(); using (Stream dataStream = response.GetResponseStream())
        {
����������� StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            responseFromServer = responseFromServer.Trim();            
            var resultado = JsonConvert.DeserializeObject<Root>(responseFromServer);             
            //cadena.Text = resultado[0].ToString();
            //dogList = resultado.ToList();
        }
        response.Close();
    }
}