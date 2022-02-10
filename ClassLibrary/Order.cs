namespace ClassLibrary;
public class Order : IDisposable
{
    public static string StandartProductDescription = "This product has no description";
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Cost { get; set; } = 0;
    public List<Product> Products { get; set; } = new List<Product>();

    public int ProductCount()
    {
        return Products.Count;
    }
    public void AddProduct(Product newProduct)
    {
        this.Cost += newProduct.Cost;
        if (newProduct.Description == "" || newProduct.Description == null)
        {
            newProduct.Description = Order.StandartProductDescription;
        }
        this.Products.Add(newProduct);
    }
    public Product GetProduct(Product product)
    {
        return this.Products.First(p => p == product);
    }
    public void RemoveProduct(Product forRemoveProduct)
    {
        this.Cost -= forRemoveProduct.Cost;
        this.Products.Remove(forRemoveProduct);
    }
    public void RemoveProduct(string forRemoveProductName)
    {
        var forRemoveProducts = this.Products.FindAll(p => p.Name == forRemoveProductName);
        foreach (var product in forRemoveProducts)
        {
            this.Cost -= product.Cost;
            this.Products.Remove(product);
        }
    }
    public void ClearProducts()
    {
        this.Cost = 0;
        this.Products.Clear();
    }
    public void Dispose()
    {
        // dispose something
    }
}
