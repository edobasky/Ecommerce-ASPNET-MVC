using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public readonly AppDbContext _context;

    // placeholder for shopping cart
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set;}

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }



        // to return the above shopping cart with item
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(n => n.Movie.Price * n.Amount).Sum();

        public void AddItemToCart(Movie movie)
        {
            //check if cart has movie,increwase by 1.
            var shoppingCartItem = _context.ShoppingCartItems
                .FirstOrDefault(n => n.Movie.id == movie.id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromShoppingCart(Movie movie)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.ShoppingCartId == ShoppingCartId && n.Movie.id == movie.id);
            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                } else
                {
                    _context.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public async Task ClearShoppingCartAsync()
        {
            // get all shopping cart
            var items =  await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();

            ShoppingCartItems = new List<ShoppingCartItem>();
        }

    }
}
