using MiniWarehouse_CSharp.Models;

namespace MiniWarehouse_CSharp.Services;

public class WarehouseService
{
    private readonly List<Warehouse> warehouses = new();

    public void AddWarehouse(Warehouse warehouse)
    {
        warehouses.Add(warehouse);
    }

    public Warehouse? GetWarehouse(int id)
    {
        return warehouses.FirstOrDefault(warehouse => warehouse.Id == id);
    }

    public List<Warehouse> GetAllWarehouses()
    {
        return warehouses;
    }
}