namespace ShoppingModelLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public double Rating { get; set; }
        public float Discount { get; set; }
        public Product()
        {
            Price = 0.0f;
            Discount = 0.5f;
            Quantity = 1;
            Rating = 0;
        }
        /// <summary>
        /// Construct the product object with the essential properties
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="name">Name of the Product</param>
        /// <param name="quantity">Quantity Available</param>
        /// <param name="price">Price of the Product</param>
        /// <param name="picture">Picture of the Product</param>
        /// <param name="description">Description about Product</param>
        /// <param name="rating">rating of Product</param>
        /// <param name="discount">Discount given to Product</param>

        public Product(int id, string name, int quantity, float price, string picture, string description, double rating, float discount)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Picture = picture;
            Description = description;
            Rating = rating;
            Discount = discount;
        }
        public override string ToString()
        {
            float netPrice = Price - (Price * Discount / 100);
            return $"Product Id : {Id}\nProduct Name : {Name}\nProduct Price : Rs. {Price}\nProduct Quantity In Hand : {Quantity}" +
                $"\nDiscount offered : {Discount}%\nRating : {Rating}\nNet Price : {netPrice}";

        }
    }
}