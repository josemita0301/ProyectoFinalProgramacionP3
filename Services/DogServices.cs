using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProyectoFinalProgramacion.Models;

namespace ProyectoFinalProgramacion.Services
{
    public class DogServices : IDogServices
    {
        private SQLiteAsyncConnection conn;

        private async Task SetUpDb()
        {
            if (conn == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "betterHome.db3");
                conn = new SQLiteAsyncConnection(dbPath);
                await conn.CreateTableAsync<Dog>();
            }
        }

        public async Task<int> AddDog(Dog dogModel)
        {
            await SetUpDb();
            return await conn.InsertAsync(dogModel);
        }

        public async Task<int> DeleteDog(Dog dogModel)
        {
            await SetUpDb();
            return await conn.DeleteAsync(dogModel);
        }

        public async Task<List<Dog>> GetDogsList()
        {
            await SetUpDb();
            var dogList = await conn.Table<Dog>().ToListAsync();
            return dogList;
        }

        public async Task<int> UpdateDog(Dog dogModel)
        {
            await SetUpDb();
            return await conn.UpdateAsync(dogModel);
        }
    }
}