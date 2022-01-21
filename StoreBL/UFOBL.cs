namespace StoreBL;

public class UFOBL : IBL
{
    private IRepo _dl;
    public UFOBL(IRepo repo)
    {
        _dl = repo;
    }

    public List<Customer> SearchCustomer(string username, string password)
    {
        return _dl.SearchCustomer(username, password);
    }
    public Customer GetCustomerById(int custId)
    {
        return _dl.GetCustomerById(custId);
    }
    public List<Customer> GetAllCustomers()
    {
        return _dl.GetAllCustomers();
    }

    public void AddCustomer(Customer newCustomer)
    {
        _dl.AddCustomer(newCustomer);
    }
    public List<Storefront> GetAllStores()
    {
        return _dl.GetAllStores();
    }
    public void AddLineItem(LineItem newLI, int orderID)
    {
        _dl.AddLineItem(newLI, orderID);
    }
    public void AddStore(Storefront storetoAdd)
    {
        _dl.AddStore(storetoAdd);
    }
    public void AddOrder(Order orderToAdd)
    {
        _dl.AddOrder(orderToAdd);
    }
    // public List<Order> GetAllOrders(int CID)
    // {
    //     return _dl.GetAllOrders(CID);
    // }
    public void AddProduct(Product productToAdd)
    {
        _dl.AddProduct(productToAdd);
    }
    public void RemoveProduct(int prodID)
    {
        _dl.RemoveProduct(prodID);
    }
    public void RestockEarthInventory(int prodID, int quantity)
    {
        _dl.RestockEarthInventory(prodID, quantity);
    }
    public List<Order> GetAllEarthOrders()
    {
        return _dl.GetAllEarthOrders();
    }
    public List<Order> GetAllCentauriOrders()
    {
        return _dl.GetAllCentauriOrders();
    }
    public void RestockCentauriInventory(int prodID, int quantity)
    {
        _dl.RestockCentauriInventory(prodID, quantity);
    }

    public Storefront GetStorefrontById(int storeID)
    {
        return _dl.GetStorefrontById((int)storeID);
    }
    public List<Product> GetAllProductsByStoreId(int storeId)
    {
        return _dl.GetAllProductsByStoreId(storeId);
    }
    public List<Inventory> GetInventoryByStoreId(int storeId)
    {
        return _dl.GetInventoryByStoreId(storeId);
    }
    public List<Inventory> GetAllInventories()
    {
        return _dl.GetAllInventories();
    }

    public void AddProductToInventory(int prodId, int storeId, int quantity)
    {
        _dl.AddProductToInventory(prodId, storeId, quantity);
    }
    public int GetProductIdByName(string name)
    {
        return _dl.GetProductIdByName(name);
    }
}