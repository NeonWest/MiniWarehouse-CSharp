namespace MiniWarehouse_CSharp.Services;

public class InventoryService{
    Dictionary<(int ProductId, int WarehouseId), int> stock = new();
    //The stock inventory

    private ProductService productService;
    private WarehouseService warehouseService;


    public InventoryService(ProductService productService, WarehouseService warehouseService) {
        this.productService = productService;
        this.warehouseService = warehouseService;
    }

    public void AddStock(int productId, int warehouseId, int quantity) {
        if (productService.GetProduct(productId) == null)
        {
            Console.WriteLine("Product not found.");
            return;
        } //product exists

        if (warehouseService.GetWarehouse(warehouseId) == null)
        {
            Console.WriteLine("Warehouse not found.");
            return;
        } //warehouse exists

        var key = (productId, warehouseId);

        if (stock.ContainsKey(key))
        {
            stock[key] += quantity;
        }
        else
        {
            stock[key] = quantity;
        }

        // basically if we have the warehouse stock already
        // add the quantity to it otherwise make stock equal
        // to quantity we have
    }

    public bool RemoveStock(int productId, int warehouseId, int quantity){
        if(productService.GetProduct(productId) == null){
            return false;
        }

        if(warehouseService.GetWarehouse(warehouseId) == null){
            return false;
        }

        var key = (productId, warehouseId);

        if(stock.ContainsKey(key) && stock[key] >= quantity){
            stock[key] -= quantity;
            return true;
        }
        else{
            return false;
        }
    }

    public int GetStock(int productId, int warehouseId) {
        var key = (productId, warehouseId);

        if (stock.ContainsKey(key))
        {
            return stock[key];
        }

        return 0;
    }

    public Dictionary<(int ProductId, int WarehouseId), int> GetAllStock() {
        return stock;
    }
}