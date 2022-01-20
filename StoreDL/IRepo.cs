global using System.Text.Json;
global using Models;
namespace StoreDL;

public interface IRepo
{
    List<Customer> GetAllCustomers();
    List<Customer> SearchCustomer(string username, string password);
    void AddCustomer(Customer newCustomer);
    Customer GetCustomerById(int custId);
    //---------------------------------------------------------------------------------------------------------------------------------
    List<Storefront> GetAllStores();
    void AddStore(Storefront storetoAdd);
    Storefront GetStorefrontById(int storeID);
    //-----------------------------------------------------------------------------------
    List<Product> GetAllProductsByStoreId(int storeId);
    int GetProductID(string productname);
    void AddProduct(Product productToAdd);
    void RemoveProduct(int prodID);
    void RestockCentauriInventory(int prodID, int quantity);
    void AddProductToInventory(int prodID, Inventory inventToAdd);
    void RestockEarthInventory(int prodID, int quantity);
    List<Inventory> GetInventoryByStoreId(int storeId);
    List<Inventory> GetAllInventories();
    //---------------------------------------------------------------------------------
    void AddLineItem(LineItem newLI, int orderID);
    void AddOrder(Order orderToAdd);
    List<Order> GetAllOrders(int CID);
    List<Order> GetAllEarthOrders();
    List<Order> GetAllCentauriOrders();
}