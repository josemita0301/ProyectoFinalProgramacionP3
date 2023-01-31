using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoFinalProgramacion.Models;
using ProyectoFinalProgramacion.Services;
using ProyectoFinalProgramacion.Views;
using System.ComponentModel;


namespace ProyectoFinalProgramacion.ViewModels
{
    [QueryProperty(nameof(DogDetail), "DogDetail")]
    public partial class UploadDogViewModel : ObservableObject
    {
        [ObservableProperty]
        private Dog _dogDetail = new Dog();

        private readonly IDogServices _dogService;
        public UploadDogViewModel(IDogServices dogService)
        {
            _dogService = dogService;
        }

        [ICommand]
        public async void AddUpdateDog()
        {
            int response = -1;
            if (DogDetail.Id > 0)
            {
                response = await _dogService.UpdateDog(DogDetail);
            }
            else
            {
                response = await _dogService.AddDog(new Models.Dog
                {
                    Name = DogDetail.Name,
                    Age = DogDetail.Age,
                    Address = DogDetail.Description,
                    Description = DogDetail.Description,
                    Color = DogDetail.Color,
                    Size = DogDetail.Size,
                    Email = DogDetail.Email,
                    imageRoute = DogDetail.imageRoute,
                });
            }



            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Dog Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Warning!", "Something went wrong while adding record", "OK");
            }
        }

    }
}