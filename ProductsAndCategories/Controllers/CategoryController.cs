using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoriesAndCategories.Controllers;

public class CategoryController : Controller
{
  private readonly ILogger<CategoryController> _logger;
  private MyContext db;

  public CategoryController(ILogger<CategoryController> logger, MyContext context)
  {
    _logger = logger;
    db = context;
  }

  [HttpGet("categories")]
  public IActionResult Categories()
  {
    List<Category> allCategories = db.Categories.ToList();
    return View("Categories", allCategories);
  }

  // Create
  [HttpPost("categories/create")]
  public IActionResult CreateCategory(Category category)
  {
    if (!ModelState.IsValid)
    {
      List<Category> allCategories = db.Categories.ToList();
      return View("Categories", allCategories);
    }
    db.Categories.Add(category);
    db.SaveChanges();
    return RedirectToAction("Categories");
  }

  // Read 
  [HttpGet("categories/{CategoryId}")]
  public IActionResult ShowCategory(int CategoryId)
  {
    Category? category = db.Categories
      .Include(category => category.AllAssociations)
      .ThenInclude(association => association.Product)
      .FirstOrDefault(first => first.CategoryId == CategoryId);
    if (category == null)
    {
      return RedirectToAction("Categories");
    }
    List<Product> availableProducts = db.Products.ToList();
    ViewData["AvailableProducts"] = availableProducts;
    return View("ViewCategory", category);
  }


  [HttpPost("/categories/addproduct")]
  public IActionResult AddProductToCategory(int ProductId, int CategoryId)
  {
    Category? category = db.Categories
      .Include(product => product.AllAssociations)
      .FirstOrDefault(product => product.CategoryId == CategoryId);
    if (category == null)
    {
      return RedirectToAction("Categories");
    }
    Product? product = db.Products.FirstOrDefault(category => category.ProductId == ProductId);
    if (product == null)
    {
      return RedirectToAction("Categories");
    }
    if (product.AllAssociations.Any(association => association.CategoryId == CategoryId))
    {
      return RedirectToAction("ShowCategory", new { CategoryId = CategoryId });
    }
    Association newAssociation = new Association
    {
      Product = product,
      Category = category
    };
    db.Associations.Add(newAssociation);
    db.SaveChanges();
    return RedirectToAction("ShowCategory", new { CategoryId = CategoryId });
  }
}