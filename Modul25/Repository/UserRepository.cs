using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modul25.Repository
{
    public class UserRepository
    {

        // выбор пользователя по идентификатру
        public User UserGetById( int id)
        {
            using (AppContext db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    Console.WriteLine($"\n Имя пользователя с id = {id}  - {user.Name}");
                }
                else
                {
                    Console.WriteLine($"\n Пользоваетель с id = {id} - не найден");
                }
                return user;
            }
        }

        // выбор всех пользователей
        public List<User> UserGetAll()
        {
            using (AppContext db = new AppContext())
            {
                Console.WriteLine("\n Список пользователей библиотеки");
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
                return users;
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
        public void UserChangeName( int id, string newName)
        {
            using (AppContext db = new AppContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.Name = newName;
                    db.SaveChanges();

                    Console.WriteLine($"\n Имя пользователя с кодом {id} изменено на  {user.Name}");
                }
                else
                {
                    Console.WriteLine($"\n Пользователь с кодом {id} не найдне. Изменения имени не возможно");
                }
            }
        }
    }
}
