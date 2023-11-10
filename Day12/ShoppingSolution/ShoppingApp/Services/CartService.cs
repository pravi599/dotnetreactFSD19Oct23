﻿using Microsoft.CodeAnalysis;
using ShoppingApp.Interfaces;
using ShoppingApp.Models;
using ShoppingApp.Models.DTOs;
using ShoppingApp.Repositories;

namespace ShoppingApp.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IRepository<int, CartItems> _cartItemRepository;
        private readonly IRepository<int, Product> _productRepository;

        public CartService(IRepository<int, Cart> cartRepository,
            IRepository<int, CartItems> cartItemRepository,
            IRepository<int, Product> productRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }
        CartItems CreateCartItem(int cartNumber, CartDTO cartDTO)
        {
            var product = _productRepository.GetById(cartDTO.ProductId);
            if (product != null)
            {
                var myCartItem = new CartItems
                {
                    CartNumber = cartNumber,
                    Product_Id = cartDTO.ProductId,
                    Quantity = cartDTO.Quantity,
                    Price = product.Price
                };
                return myCartItem;
            }
            return null;
        }
        public bool AddToCart(CartDTO cartDTO)
        {

            var cartCheck = _cartRepository.GetAll().FirstOrDefault(c => c.Username == cartDTO.Username);
            int cartNumber = 0;
            if (cartCheck == null)
            {
                var cart = _cartRepository.Add(new Cart { Username = cartDTO.Username });
                cartNumber = cart.cartNumber;
            }
            else
                cartNumber = cartCheck.cartNumber;
            bool CartItemCheck = CheckIfCartItemAlreadyPresent(cartNumber, cartDTO.ProductId);
            if (CartItemCheck)
            {
                return IncrementQuantityInCart(cartNumber, cartDTO);
            }
            var myCartItem = CreateCartItem(cartNumber, cartDTO);
            if (myCartItem != null)
            {
                var result = _cartItemRepository.Add(myCartItem);
                if (result != null)
                    return true;
            }
            return false;
        }

        private bool IncrementQuantityInCart(int cartNumber, CartDTO cartDTO)
        {
            var cartItem = _cartItemRepository.GetAll()
                .FirstOrDefault(ci => ci.CartNumber == cartNumber && ci.Product_Id == cartDTO.ProductId);
            cartItem.Quantity += cartDTO.Quantity;
            var result = _cartItemRepository.Update(cartItem);
            if (result != null)
                return true;
            return false;
        }

        private bool CheckIfCartItemAlreadyPresent(int cartNumber, int productId)
        {
            var cartItem = _cartItemRepository.GetAll()
                .FirstOrDefault(ci => ci.CartNumber == cartNumber && ci.Product_Id == productId);
            return cartItem != null ? true : false;
        }

        public bool RemoveFromCart(CartDTO cartDTO)
        {
            var cartCheck = _cartRepository.GetAll().FirstOrDefault(c => c.Username == cartDTO.Username);
            if (cartCheck == null)
            {
                // The cart doesn't exist, so there's nothing to remove.
                return false;
            }

            var cartNumber = cartCheck.cartNumber;
            var cartItem = _cartItemRepository.GetAll()
                .FirstOrDefault(ci => ci.CartNumber == cartNumber && ci.Product_Id == cartDTO.ProductId);

            if (cartItem != null)
            {
                // The cart item exists, so we can update its quantity or remove it.
                if (cartItem.Quantity > cartDTO.Quantity)
                {
                    // Decrease the quantity based on the request.
                    cartItem.Quantity -= cartDTO.Quantity;
                    _cartItemRepository.Update(cartItem);
                }
                else
                {
                    // If the requested quantity is greater or equal to the cart item's quantity, remove it.
                    _cartItemRepository.Delete(cartItem.Product_Id);
                }

                return true;
            }

            return false;
        }

    }
}
