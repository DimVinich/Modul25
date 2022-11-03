using Modul25.Entities;
using Modul25.Repository;
using System;

namespace Modul25
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new AppContext())
            {

                // Добавление пользователей
                var user1 = new User { Name = "Alice", Email = "Alisa@gmail.com" };
                var user2 = new User { Name = "Dima", Email = "Dima@gmail.com" };
                var user3 = new User { Name = "Nina", Email = "Nina@gmail.com" };
                var user4 = new User { Name = "Vano", Email = "Vano@gmail.com" };

                //  Добавление книг
                var book1 = new Book { Title = "Тайна", YearOfPublication = 2020, Author = "Пупкин", Genre = "чтото" };
                var book2 = new Book { Title = "Тайна2", YearOfPublication = 2021, Author = "Пупкин", Genre = "чтото" };
                var book3 = new Book { Title = "Небо", YearOfPublication = 2021, Author = "Иванов", Genre = "фэнтези" };
                var book4 = new Book { Title = "Дождь", YearOfPublication = 2022, Author = "Рогин", Genre = "фэнтези" };
                var book5 = new Book { Title = "Замля", YearOfPublication = 2022, Author = "Копытин", Genre = "Попаданец" };

                //  Назначение книг по пользователям
                //  Ситуация, что 3-я книга не на руках.
                book1.User = user1;
                user1.Books.Add(book2);

                user2.Books.Add(book4);
                user2.Books.Add(book5);

                db.Users.AddRange(user2, user3, user1, user4);
                db.Books.AddRange(book1, book2, book4, book3, book5);

                db.SaveChanges();
            }

            UserRepository userRepository = new UserRepository();

            userRepository.UserGetAll();

            var newUser = new User { Name = "Добавлен", Email = "AddUser@gmail.com" };
            userRepository.UserAdd(newUser);
            userRepository.UserGetAll();

            userRepository.UserDelete(newUser);
            userRepository.UserGetAll();

            userRepository.UserGetById(15);
            userRepository.UserGetById(3);

            userRepository.UserChangeName(3, "Новое имя");
            userRepository.UserGetAll();
            userRepository.UserChangeName(3, "Alice");

            BookRepository bookRepository = new BookRepository();

            bookRepository.BookGetAll();

            bookRepository.BookGetById(3);
            bookRepository.BookGetById(15);

            var newBook = new Book { Title = "New Book", Author = "New Autor", Genre ="New Gener", YearOfPublication = 2022 };
            bookRepository.BookAdd(newBook);
            bookRepository.BookGetAll();

            bookRepository.BookDelete(newBook);
            bookRepository.BookGetAll();

            bookRepository.BookChangeYearOfPubclication(3, 1999);
            bookRepository.BookGetAll();
            bookRepository.BookChangeYearOfPubclication(3, 2022);

            bookRepository.BookGetGenreForPeriod("чтото", 2019, 2021);

            bookRepository.BookGetCountByAutor("Пупкин");

            bookRepository.BookGetCountByGenre("чтото");

            bookRepository.BookHaveAuthorTitle("Пупкин", "Тайна");

            var findeBook = new Book { Title = "", Author = "", Genre = "", YearOfPublication = 2022, Id = 3 };
            bookRepository.BookAtUser(findeBook);

            bookRepository.BookCountBooksOfUsers();

            bookRepository.BookGetLatest();

            bookRepository.BookGetAllOrderByTitle();

            bookRepository.BookGetAllOrderByYear();

            Console.ReadKey();
        }
    }
}
