using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _450MIST.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _450MIST.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace _450MIST.Controllers

    //Controller (base class)
    public class BookController : Controller
    {
        private BooksDBContext _context; //will hold a reference to the database object

        public BookController(BooksDBContext context)
        {
            _context = context; //passes the reference to the database in the _context variable
        }

        // GET: /<controller>/
        public IActionResult Index() //method that allows us to read the information from the database
        {
            List<Book> booksList = _context.books.ToList(); //gets a list of all the books in the books table

            //??passing booksList to the view
            return View(booksList);

            //pass the data to the view that will display the data
        }

        //HTTP get request - getting the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //HTTP post request - post the data
        //get and save the data to the database
        //overloaded method
        //Book -
        //books - is the table reference (BooksDBContext)

        [HttpPost]
        public IActionResult Create(Book bookObj)
        {
            _context.books.Add(bookObj); //getting ready to add the book
            _context.SaveChanges(); //this is when we actually add the book to the database

            return RedirectToAction("Index", "Book");
        }
    }
