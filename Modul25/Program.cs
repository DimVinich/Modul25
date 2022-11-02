using Modul25.Entities;
using Modul25.Repository;
using System;

namespace Modul25
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (var db = new AppContext())
            //{

            //    // Добавление пользователей
            //    var user1 = new User { Name = "Alice", Email = "Alisa@gmail.com" };
            //    var user2 = new User { Name = "Dima", Email = "Dima@gmail.com" };
            //    var user3 = new User { Name = "Nina", Email = "Nina@gmail.com" };
            //    var user4 = new User { Name = "Vano", Email = "Vano@gmail.com" };

            //    //  Добавление книг
            //    var book1 = new Book { Title = "Тайна", YearOfPublication = 2020, Author = "Пупкин", Genre = "чтото" };
            //    var book2 = new Book { Title = "Тайна2", YearOfPublication = 2021, Author = "Пупкин", Genre = "чтото" };
            //    var book3 = new Book { Title = "Небо", YearOfPublication = 2021, Author = "Иванов", Genre = "фэнтези" };
            //    var book4 = new Book { Title = "Дождь", YearOfPublication = 2022, Author = "Рогин", Genre = "фэнтези" };
            //    var book5 = new Book { Title = "Замля", YearOfPublication = 2022, Author = "Копытин", Genre = "Попаданец" };

            //    //  Назначение книг по пользователям
            //    //  Ситуация, что 3-я книга не на руках.
            //    book1.User = user1;
            //    user1.Books.Add(book2);

            //    user2.Books.Add(book4);
            //    user2.Books.Add(book5);

            //    db.Users.AddRange(user2, user3, user1, user4);
            //    db.Books.AddRange(book1, book2, book4, book3, book5);

            //    db.SaveChanges();
            //}

            UserRepository userRepository = new UserRepository();

            userRepository.UserGetAll();

            //var newUser = new User { Name = "Добавлен", Email = "Vano@gmail.com" };
            //userRepository.UserAdd(newUser);
            //userRepository.UserGetAll();
            //userRepository.UserDelete(newUser);
            //userRepository.UserGetAll();

            //userRepository.UserGetById(15);



            Console.ReadKey();
        }
    }
}
