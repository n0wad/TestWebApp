
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebService.Models;
using TestWebService.Data;

namespace TestWebService.Controllers;

public class OrdersMvcController : Controller
{
    private readonly AppDbContext _context;

    public OrdersMvcController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()    
    {
        return View(await _context.Orders.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _context.Orders.FindAsync(id); 
        
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var order = new Order
        {
            OrderNumber = Guid.NewGuid().ToString().Substring(0, 8),
            SenderCity = request.SenderCity,
            SenderAddress = request.SenderAddress,
            ReceiverCity = request.ReceiverCity,
            ReceiverAddress = request.ReceiverAddress,
            Weight = request.Weight,
            PickupDate = request.PickupDate
        };

        _context.Add(order);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _context.Orders
            .FirstOrDefaultAsync(m => m.Id == id);
        if (order == null)
        {
            return NotFound();
        }

        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
