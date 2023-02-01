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
        Item.fact = factRandom.Text;
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

    //Implementación de la API
    private void OnGenerateClicked(object sender, EventArgs e)
    {
        WebRequest request = WebRequest.Create("https://dogapi.dog/api/v2/facts");
        //request.Headers.Add("", "YOUR API KEY HERE");
        WebResponse response = request.GetResponse();
        //var client = new HttpClient();

        using (Stream dataStream = response.GetResponseStream())
        {
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            responseFromServer = responseFromServer.Trim();
            var resultado = JsonConvert.DeserializeObject<Rootobject>(responseFromServer); // nombre de la clase q viene de la api - og json - objeto
            // retorna lista

            // generar num rec random
            Random rnd = new Random();
            int numRnd = rnd.Next(0, 200);
            int numLista = numRnd;

            factRandom.Text = resultado.data[0].attributes.body;


        }
        response.Close();
    }
}