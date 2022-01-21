namespace StoreBL;

public interface IBL
{
    List<Customer> GetAllCustomers();
    List<Customer> SearchCustomer(string username, string password);
    void AddCustomer(Customer newCustomer);
    Customer GetCustomerById(int custId);
    //-----------------------------------------------------------------------------------------------------------------
    List<Storefront> GetAllStores();
    Storefront GetStorefrontById(int storeID);
    void AddStore(Storefront storetoAdd);
    //-----------------------------------------------------------------------------------------------------------------
    List<Product> GetAllProductsByStoreId(int storeId);
    void AddProduct(Product productToAdd);
    void RemoveProduct(int prodID);
    List<Inventory> GetInventoryByStoreId(int storeId);
    void RestockEarthInventory(int prodID, int quantity);
    void RestockCentauriInventory(int prodID, int quantity);
    void AddProductToInventory(int prodID, Inventory inventToAdd);
    List<Inventory> GetAllInventories();
    //-------------------------------------------------------------------------------------------
    void AddLineItem(LineItem newLI, int orderID);
    void AddOrder(Order orderToAdd);
    // List<Order> GetAllOrders(int CID);
    List<Order> GetAllEarthOrders();
    List<Order> GetAllCentauriOrders();

}