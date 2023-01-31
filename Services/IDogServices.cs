using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Services
{
    public interface IDogServices
    {
        Task<List<Dog>> GetDogsList();
        Task<int> AddDog(Dog dogModel);
        Task<int> DeleteDog(Dog dogModel);
        Task<int> UpdateDog(Dog dogModel);
    }
}