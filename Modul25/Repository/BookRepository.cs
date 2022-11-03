﻿using Modul25.Entities;
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

    }
}
