using BookCatalogue.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookCatalogue.DAL
{
    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var books = new List<Book>
            {
                new Book{Id = 1, Name = "Война и мир", Author = "Толстой Л.Н.", Year = 1865, PublishingHouse = "Русский вестник", Genre = Genre.Novel },
                new Book{Id = 2, Name = "Анна Каренина", Author = "Толстой Л.Н.", Year = 1878, PublishingHouse = "Русский вестник", Genre = Genre.Novel},
                new Book{Id = 3, Name = "Евгений Онегин", Author = "Пушкин А.С.", Year = 1988, PublishingHouse = "Книга", Genre = Genre.Novel},
                new Book{Id = 4, Name = "Мастер и Маргарита", Author = "Булгаков М.А.", Year = 1967, PublishingHouse = "YMCA-Press", Genre = Genre.Novel},
                new Book{Id = 5, Name = "Преступление и наказание", Author = "Достоевский Ф.М.", Year = 1866, PublishingHouse = "Русский вестник", Genre = Genre.Novel},
                new Book{Id = 6, Name = "Убийство в восточном экспрессе", Author = "Агата Кристи", Year = 2014, PublishingHouse = "Эксмо", Genre = Genre.Detective},
                new Book{Id = 7, Name = "Девушка с татуировкой дракона", Author = "Стиг Ларсон", Year = 2013, PublishingHouse = "Эксмо", Genre = Genre.Detective},
                new Book{Id = 8, Name = "451 градус по Фаренгейту", Author = "Рэй Бредбери", Year = 1953, PublishingHouse = "Ballantine Books", Genre = Genre.Fantasy},
                new Book{Id = 9, Name = "Цветы для Элджернона", Author = "Дэниел Киз", Year = 2017, PublishingHouse = "АСТ", Genre = Genre.Fantasy},
                new Book{Id = 10, Name = "Приключения Тома Сойера", Author = "Марк Твен", Year = 2017, PublishingHouse = "Нигма", Genre = Genre.Adventure}
            };
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
        }
    }
}