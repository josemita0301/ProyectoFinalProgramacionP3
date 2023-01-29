using ProyectoFinalProgramacion.Models;
using SQLite;

namespace ProyectoFinalProgramacion.Data
{
    public class BetterHomeDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public BetterHomeDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null) return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<User>();
            conn.CreateTable<Dog>();
        }
        //Add data to the database
        public int AddNewDog(Dog dog)
        {
            Init();

            if (dog.Id != 0)
            {
                return conn.Update(dog);
            }
            else
            {
                return conn.Insert(dog);
            }
        }

        public int AddNewUser(User user)
        {
            Init();

            if (user.Id != 0)
            {
                return conn.Update(user);
            }
            else
            {
                List<User> usuarios = GetAllUsers().ToList();

                foreach (User usuario in usuarios)
                {
                    if (user.UserName == usuario.UserName)
                    {
                        return 0;
                    }
                }
                return conn.Insert(user);
            }
        }


        //get all data from the database

        public List<Dog> GetAllDogs()
        {
            Init();
            List<Dog> dogs = conn.Table<Dog>().ToList();
            return dogs;
        }

        public List<User> GetAllUsers()
        {
            Init();
            List<User> users = conn.Table<User>().ToList();
            return users;
        }

        //Delete info from database
        public int DeleteDog(Dog dog)
        {
            Init();
            return conn.Delete(dog);
        }

        public int DeleteUser(User user)
        {
            Init();
            return conn.Delete(user);
        }
    }
}
