using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modul25.Repository
{
    public class UserRepository
    {

        // выбор пользователя по идентификатру
        public void UserGetById( int id)
        {
            using (AppContext db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                Console.WriteLine($"\n Имя пользователя с id = {id}  - {user.Name}");
            }
        }

        // выбор всех пользователей
        public void UserGetAll()
        {
            using (AppContext db = new AppContext())
            {
                Console.WriteLine("\n Список пользователей библиотеки");
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }

        //  добавление пользователя
        public void UserAdd(User user)
        {
            using (AppContext db = new AppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            Console.WriteLine($"\n Пользователь {user.Name}  добавлен");
        }

        //  удаление пользователя
        public void UserDelete( User user )
        {
            using (AppContext db = new AppContext())
            {
                db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
            Console.WriteLine($"\n Пользователь {user.Name}  удалён");

        }

        //  обновление имени пользователя по id
        //public void 
    }
}
