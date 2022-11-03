using Modul25.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modul25.Repository
{
    public class BookRepository
    {
        // выбор книги по идентификатру
        public Book BookGetById(int id)
        {
            using (AppContext db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(u => u.Id == id);
                if (book != null)
                {
                    Console.WriteLine($"\n Название книги с id = {id}  - {book.Title}");
                }
                else
                {
                    Console.WriteLine($"\n Книга с id = {id} - не найдена");
                }
                return book;
            }
        }

        // выбор всех книг
        public List<Book> BookGetAll()
        {
            using (AppContext db = new AppContext())
            {
                Console.WriteLine("\n Список книг ");
                var books = db.Books.ToList();
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}   {book.Author}   {book.Genre}  {book.YearOfPublication}");
                }
                return books;
            }
        }

        //  добавление книги
        public void BookAdd(Book book)
        {
            using (AppContext db = new AppContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            Console.WriteLine($"\n Книга с названием {book.Title}  добавлена");
        }

        //  Удаление книги 
        public void BookDelete(Book book)
        {
            using (AppContext db = new AppContext())
            {
                db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
            Console.WriteLine($"\n Книга {book.Title}  удалёна");
        }

        //  Обновление года выпуска книги по id
        public void BookChangeYearOfPubclication(int idBook, int newYear )
        {
            using (AppContext db = new AppContext())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == idBook);
                if (book != null)
                {
                    book.YearOfPublication = newYear;
                    Console.WriteLine($" Год издания книги {book.Title} изменён на {newYear}");
                }
                else
                {
                    Console.WriteLine($" Книга с кодом {idBook}  не найдена.");
                }
            }
        }

        // Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> BookGetGenreForPeriod( string genre, int yearFrom, int yearTo)
        {
            using (AppContext db = new AppContext())
            {
                var books =  db.Books.Where(b => b.Genre == genre && (b.YearOfPublication > yearFrom && b.YearOfPublication < yearTo)).ToList();
                return books;
            }
        }

        // Получать количество книг определенного автора в библиотеке.
        public int BookGetCountByAutor(string autor)
        {
            using (AppContext db = new AppContext())
            {
                var countBooks = db.Books.Count(b => b.Author == autor);
                return countBooks;
            }
        }

        //  Получать количество книг определенного жанра в библиотеке.
        public int BookGetCountByGenre(string genre)
        {
            using (AppContext db = new AppContext())
            {
                var countBooks = db.Books.Count(b => b.Genre == genre);
                return countBooks;
            }
        }

        //  Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        public bool BookHaveAuthorTitle( string author, string title)
        {
            using (AppContext db = new AppContext())
            {
                var haveBook = db.Books.Where(b => b.Author == author && (b.Title == title)).ToList();
                if ( haveBook == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //  Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool BookAtUser (Book book)
        {
            using (AppContext db = new AppContext())
            {
                var bookAtUser = db.Books.Where(b => b.Id == book.Id && (b.User != null)).ToList();
                if (bookAtUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }

        }

        //  Получать количество книг на руках у пользователя.
        public int BookCountBooksOfUsers()
        {
            using (AppContext db = new AppContext())
            {
                var countBooks = db.Books.Where(b => b.User != null).Count();
                return countBooks;
            }
            
        }

        // Получение последней вышедшей книги.
        public Book BookGetLatest()
        {
            using (AppContext db = new AppContext())
            {
                var book = db.Books.FirstOrDefault( b => b.YearOfPublication == db.Books.Max(b2 => b2.YearOfPublication));
                return book;
            }
        }

        //  Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> BookGetAllOrderByTitle()
        {
            using (AppContext db = new AppContext())
            {
                var books = db.Books.OrderBy(b => b.Title).ToList();
                return books;
            }

        }

        //  Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book> BookGetAllOrderByYear()
        {
            using (AppContext db = new AppContext())
            {
                var books = db.Books.OrderByDescending(b => b.YearOfPublication).ToList();
                return books;
            }
            
        }

    }
}
