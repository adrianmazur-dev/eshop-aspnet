using EShop.Core.Entities;
using EShop.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartController(ICartService cartService, UserManager<ApplicationUser> userManager)
    {
        _cartService = cartService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);
        var cart = await _cartService.GetCartByUserIdAsync(userId);
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int catalogItemId, int quantity)
    {
        var userId = _userManager.GetUserId(User);
        await _cartService.AddItemToCartAsync(userId, catalogItemId, quantity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int catalogItemId)
    {
        var userId = _userManager.GetUserId(User);
        await _cartService.RemoveItemFromCartAsync(userId, catalogItemId);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ClearCart()
    {
        var userId = _userManager.GetUserId(User);
        await _cartService.ClearCartAsync(userId);
        return RedirectToAction("Index");
    }
}