using BookCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace BookCatalogue.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Book> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/");
                //HTTP GET
                var responseTask = client.GetAsync("books");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Book>>();
                    readTask.Wait();

                    books = readTask.Result;
                }
                else
                {

                    books = Enumerable.Empty<Book>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/books");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Book>("books", book);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error");

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/");
                //HTTP GET
                var responseTask = client.GetAsync("books?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/books");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Book>("books", book);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("books/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Book book = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/");
                //HTTP GET
                var responseTask = client.GetAsync("books?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Book>();
                    readTask.Wait();

                    book = readTask.Result;
                }
            }

            return View(book);
        }

        public ActionResult Genre(string genre)
        {
            IEnumerable<Book> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53539/api/");
                //HTTP GET
                var responseTask = client.GetAsync("books?genre=" + genre);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync< IEnumerable<Book>> ();
                    readTask.Wait();

                    books = readTask.Result;
                }
            }

            return View("Index", books);
        }
    }
}