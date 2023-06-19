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

  // Create new category
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

  // Get one Category
  [HttpGet("categories/{CategoryId}")]
  public IActionResult ShowCategory(int CategoryId)
  {
    Category? category = db.Categories
      .Include(c => c.AllAssociations)
      .ThenInclude(a => a.Product)
      .FirstOrDefault(d => d.CategoryId == CategoryId);
    if (category == null)
    {
      return RedirectToAction("Categories");
    }
    List<Product> availableProducts = db.Products.ToList();
    ViewData["AvailableProducts"] = availableProducts;
    return View("ViewCategory", category);
  }

  // Add product to category
  [HttpPost("/categories/addproduct")]
  public IActionResult AddProductToCategory(int ProductId, int CategoryId)
  {
    Category? category = db.Categories
      .Include(p => p.AllAssociations)
      .FirstOrDefault(p => p.CategoryId == CategoryId);
    if (category == null)
    {
      return RedirectToAction("Categories");
    }
    Product? product = db.Products.FirstOrDefault(c => c.ProductId == ProductId);
    if (product == null)
    {
      return RedirectToAction("Categories");
    }
    // Check if the category is already associated with the product
    if (product.AllAssociations.Any(a => a.CategoryId == CategoryId))
    {
      // Category already associated, do not add again
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