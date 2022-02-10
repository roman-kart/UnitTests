using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using ClassLibrary;

namespace ClassLibraryTests;

[TestClass]
public class Order_InitAndCleanUp
{
    private Order _order;
    private Product _product;
    [TestMethod]
    public void OrderProducts_AddCookie_OrderProductsContainsCookie()
    {
        // arrange
        var productName = "Chocolate Chip Cookies";
        var productCost = 50;
        var productDescription = "Beautiful Chocolate Chip Cookies";
        var isContainsExpected = true;

        // act
        var newProduct = new Product() { Name = productName, Cost = productCost, Description = productDescription };
        _order.AddProduct(newProduct);

        // Assert
        var isContainsResult = _order.Products.Contains(newProduct);
        Assert.IsTrue(isContainsExpected == isContainsResult, "Products doesn't contains new product");
    }
    [TestMethod]
    public void OrderProducts_CleanProducts_OrderProductListIsEmpty()
    {
        // arrange
        var isProductListEmptyExpected = true;

        // act
        _order.Products.Clear();

        // assert
        var isProductListEmptyResult = _order.Products.Count == 0;
        Assert.IsTrue(isProductListEmptyExpected == isProductListEmptyResult, "Product list isn't empty");
    }
    // данный метод запускаетс€ перед каждым вызовом Unit-теста
    [TestInitialize]
    public void TestInitialize()
    {
        Debug.WriteLine("Initializing something before starting the test");

        this._product = new Product() { 
            Name = "Milk", 
            Cost = 100, 
            Description = "¬кусное молоко!"
        };
        this._order = new Order() { 
            OrderID = 1, 
            CreatedDate = System.DateTime.Now, 
            CustomerName = "Ivanov Ivan Ivanovich",
            Cost = 100
        };
        this._order.Products.Add(_product);
    }
    [TestCleanup]
    public void TestCleanUp()
    {
        Debug.WriteLine("Cleaning up something after completing the test");
        this._product.Dispose();
        this._order.Dispose();
    }
}