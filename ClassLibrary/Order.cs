namespace ClassLibrary;
public class Order : IDisposable
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Cost { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();

    public int ProductCount()
    {
        return Products.Count;
    }
    public void AddProduct(Product newProduct)
    {
        this.Products.Add(newProduct);
    }
    public void RemoveProduct(Product forRemoveProduct)
    {
        this.Products.Remove(forRemoveProduct);
    }
    public void RemoveProduct(string forRemoveProductName)
    {
        this.Products.RemoveAll(p => p.Name == forRemoveProductName);
    }

    public void Dispose()
    {
        // dispose something
    }
}
