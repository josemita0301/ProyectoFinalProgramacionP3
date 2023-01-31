using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Services
{
    public class UserServices : IUserServices
    {
        private SQLiteAsyncConnection conn;

        private async Task SetUpDb()
        {
            if (conn == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "betterHome.db3");
                conn = new SQLiteAsyncConnection(dbPath);
                await conn.CreateTableAsync<User>();
            }
        }

        public async Task<int> AddUser(User userModel)
        {
            await SetUpDb();
            return await conn.InsertAsync(userModel);
        }

        public async Task<int> DeleteUser(User userModel)
        {
            await SetUpDb();
            return await conn.DeleteAsync(userModel);
        }

        public async Task<List<User>> GetUsersList()
        {
            await SetUpDb();
            var userList = await conn.Table<User>().ToListAsync();
            return userList;
        }

        public async Task<int> UpdateUser(User userModel)
        {
            await SetUpDb();
            return await conn.UpdateAsync(userModel);
        }
    }
}