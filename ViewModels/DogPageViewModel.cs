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

namespace ProyectoFinalProgramacion.ViewModels
{
    public partial class DogPageViewModel : ObservableObject
    {
        public static List<Dog> DogListForSearch { get; private set; } = new List<Dog>();
        public ObservableCollection<Dog> Dogs { get; set; } = new ObservableCollection<Dog>();

        private readonly IDogServices _dogServices;
        public DogPageViewModel(IDogServices dogServices)
        {
            _dogServices = dogServices;
        }



        [ICommand]
        public async void GetDogsList()
        {
            Dogs.Clear();
            var dogList = await _dogServices.GetDogsList();
            if (dogList?.Count > 0)
            {
                dogList = dogList.OrderBy(f => f.Name).ToList();
                foreach (var dog in dogList)
                {
                    Dogs.Add(dog);
                }
                DogListForSearch.Clear();
                DogListForSearch.AddRange(dogList);
            }
        }


        [ICommand]
        public async void AddUpdateDog()
        {
            await AppShell.Current.GoToAsync(nameof(UploadDogPage));
        }


        [ICommand]
        public async void DisplayAction(Dog dogModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "DogDetail", dogModel }
                };
                await AppShell.Current.GoToAsync(nameof(UploadDogPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _dogServices.DeleteDog(dogModel);
                if (delResponse > 0)
                {
                    GetDogsList();
                }
            }
        }
    }
}