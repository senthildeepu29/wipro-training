using Microsoft.AspNetCore.Mvc;
using BookstoreApp.DAL;
using BookstoreApp.Models;

namespace BookstoreApp.Controllers;

public class BookController : Controller {
    private readonly BookDAL _dal = new();

    public IActionResult Index() => View(_dal.GetBooks());

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Book book) {
        if (ModelState.IsValid) {
            _dal.AddBook(book);
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public IActionResult Edit(int id) {
        var book = _dal.GetBookById(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book) {
        if (ModelState.IsValid) {
            _dal.UpdateBook(book);
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public IActionResult Delete(int id) {
        var book = _dal.GetBookById(id);
        return book == null ? NotFound() : View(book);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id) {
        _dal.DeleteBook(id);
        return RedirectToAction("Index");
    }
}
