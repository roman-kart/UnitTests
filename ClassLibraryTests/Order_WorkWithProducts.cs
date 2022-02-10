using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using ClassLibrary;
using System.Linq;
using System;

namespace ClassLibraryTests;

[TestClass]
public class Order_WorkWithProducts
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
    [TestMethod]
    public void OrderProducts_AddTwoProductsWithSummaryCost100_SumEquals100WithDelta1()
    {
        // arrange
        var delta = 1;
        var expected = 100;

        var product1Name = "Test1";
        var product1Cost = Convert.ToInt32(50.6);
        var product1 = new Product() { Name = product1Name, Cost = product1Cost, };

        var product2Name = "Test2";
        var product2Cost = Convert.ToInt32(50.4);
        var product2 = new Product() { Name = product2Name, Cost = product2Cost, };

        // act
        _order.ClearProducts();
        _order.AddProduct(product1);
        _order.AddProduct(product2);
        var actual = _order.Cost;

        Debug.WriteLine("Products in order: ");
        foreach (var product in _order.Products)
        {
            Debug.WriteLine($"\t{product.Name}, {product.Cost}");
        }

        // assert
        Assert.AreEqual(expected, actual, delta, $"Expected: {expected} with delta {delta}, but actual: {actual}");
    }
    [TestMethod]
    public void OrderProducts_AddTestProduct_OrderProductsDescriptionHasStandartValue()
    {
        // arrange
        var productName = "Test1";
        var productCost = 100;
        var expected = "This product has no description";

        // act
        var testProduct = new Product() { Name = productName, Cost = productCost, };
        _order.AddProduct(testProduct);

        // assert
        var actual = _order.GetProduct(testProduct).Description;
        Assert.AreEqual(expected, actual, false);
    }
    [TestMethod]
    public void OrderProducts_DeleteFirstProduct_ProductListMustNotToContainsThisProduct()
    {
        // act
        try
        {
            var firstProduct = _order.Products.First(); // если список пуст, то будет сгенерировано исключение
            _order.RemoveProduct(firstProduct);
            CollectionAssert.DoesNotContain(_order.Products, firstProduct);
        }
        catch (ArgumentNullException arg)
        {
            Assert.Fail(arg.Message);
        }
        catch(InvalidOperationException oper)
        {
            Assert.Fail(oper.Message);
        }
    }
    [TestMethod]
    public void OrderProducts_AllItemsMustToBeUnique()
    {
        CollectionAssert.AllItemsAreUnique(_order.Products);
    }
    [TestMethod]
    public void OrderProducts_AllItemsMustToBeNotNull()
    {
        CollectionAssert.AllItemsAreNotNull(_order.Products);
    }
    /// <summary>
    /// ѕеред каждым выполнением теста присваивает переменным _product и _order шаблонные значени€.
    /// </summary>
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