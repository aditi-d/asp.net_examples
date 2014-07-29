using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestMvcApplication2.Models;

namespace TestMvcApplication2.Controllers
{
    public class BooksController : ApiController
    {
        static readonly IBookRepository _repository = new BookRepository();

        public HttpResponseMessage PostBook(Book book)
        {
            book = _repository.Add(book);
            var response = Request.CreateResponse<Book>(HttpStatusCode.Created, book);
            string uri = Url.Route(null, new { id = book.Id });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }
    }
}
