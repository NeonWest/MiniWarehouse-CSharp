namespace MiniWarehouse_CSharp.Services;

public class InventoryService{
    Dictionary<(int ProductId, int WarehouseId), int> stock = new();
    //The stock inventory

    public void AddStock(int productId, int warehouseId, int quantity){
        var key = (productId, warehouseId);

        if(stock.ContainsKey(key)){
            stock[key] += quantity;
        }
        else{
            stock[key] = quantity;
        }
        //basically if we have the warehouse stock already
        //add the quantity to it otherwise make stock equal
        //to quantity we have
    }

    public bool RemoveStock(int productId, int warehouseId, int quantity){
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