using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Services
{
    public interface UserServices
    {
        Task<List<User>> GetUsersList();
        Task<int> AddUser(User userModel);
        Task<int> DeleteUser(User userModel);
        Task<int> UpdateUser(User userModel);
    }
}