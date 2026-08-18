using MiniWarehouse_CSharp.Models;
using MiniWarehouse_CSharp.Services;

namespace MiniWarehouse_CSharp.Tests;

public class InventoryServiceTests{
    private ProductService productService;
    private WarehouseService warehouseService;
    private InventoryService inventoryService;

    public InventoryServiceTests(){
        productService = new ProductService();
        warehouseService = new WarehouseService();

        productService.AddProduct(new Product{
            Id = 1,
            Sku = "KB-001",
            Name = "Mechanical Keyboard",
            Price = 79.99m
        });

        warehouseService.AddWarehouse(new Warehouse{
            Id = 1,
            Name = "Main Warehouse",
            Location = "Budapest"
        });

        inventoryService = new InventoryService(
            productService,
            warehouseService
        );
    }

    [Fact]
    public void AddStock_ShouldIncreaseStock(){
        inventoryService.AddStock(1, 1, 50);

        var result = inventoryService.GetStock(1, 1);

        Assert.Equal(50, result);
    }

    [Fact]
    public void AddStock_ShouldAddToExistingStock(){
        inventoryService.AddStock(1, 1, 50);
        inventoryService.AddStock(1, 1, 20);

        var result = inventoryService.GetStock(1, 1);

        Assert.Equal(70, result);
    }

    [Fact]
    public void RemoveStock_ShouldDecreaseStock(){
        inventoryService.AddStock(1, 1, 50);

        var result = inventoryService.RemoveStock(1, 1, 20);

        Assert.True(result);
        Assert.Equal(30, inventoryService.GetStock(1, 1));
    }

    [Fact]
    public void RemoveStock_ShouldFail_WhenNotEnoughStock(){
        inventoryService.AddStock(1, 1, 10);

        var result = inventoryService.RemoveStock(1, 1, 20);

        Assert.False(result);
        Assert.Equal(10, inventoryService.GetStock(1, 1));
    }

    [Fact]
    public void AddStock_ShouldNotAdd_WhenProductDoesNotExist(){
        inventoryService.AddStock(999, 1, 50);

        var result = inventoryService.GetStock(999, 1);

        Assert.Equal(0, result);
    }

    [Fact]
    public void AddStock_ShouldNotAdd_WhenWarehouseDoesNotExist(){
        inventoryService.AddStock(1, 999, 50);

        var result = inventoryService.GetStock(1, 999);

        Assert.Equal(0, result);
    }
}