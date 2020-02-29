using shop_shop.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace shop_shop.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.bookId == id).FirstOrDefault();

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.bookId == id, bookIn);

        public void Remove(Book bookIn) =>
            _books.DeleteOne(book => book.bookId == bookIn.bookId);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.bookId == id);
    }
}