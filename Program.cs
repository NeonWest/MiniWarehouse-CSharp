using MiniWarehouse_CSharp.Services;

var inventoryService = new InventoryService();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("=== Mini Warehouse ===");
    Console.WriteLine("1. Add Stock");
    Console.WriteLine("2. Remove Stock");
    Console.WriteLine("3. Check Stock");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddStock();
            break;

        case "2":
            RemoveStock();
            break;

        case "3":
            CheckStock();
            break;

        case "4":
            Console.WriteLine("Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}

void AddStock()
{
    var productId = ReadNumber("Product ID: ");
    var warehouseId = ReadNumber("Warehouse ID: ");
    var quantity = ReadNumber("Quantity: ");

    if (quantity <= 0)
    {
        Console.WriteLine("Quantity must be greater than 0.");
        return;
    }

    inventoryService.AddStock(productId, warehouseId, quantity);

    Console.WriteLine("Stock added successfully.");
}

void RemoveStock()
{
    var productId = ReadNumber("Product ID: ");
    var warehouseId = ReadNumber("Warehouse ID: ");
    var quantity = ReadNumber("Quantity: ");

    if (quantity <= 0)
    {
        Console.WriteLine("Quantity must be greater than 0.");
        return;
    }

    var success = inventoryService.RemoveStock(
        productId,
        warehouseId,
        quantity
    );

    if (success)
    {
        Console.WriteLine("Stock removed successfully.");
    }
    else
    {
        Console.WriteLine("Not enough stock or product not found.");
    }
}

void CheckStock()
{
    var productId = ReadNumber("Product ID: ");
    var warehouseId = ReadNumber("Warehouse ID: ");

    var quantity = inventoryService.GetStock(
        productId,
        warehouseId
    );

    Console.WriteLine($"Current stock: {quantity}");
}

int ReadNumber(string message)
{
    while (true)
    {
        Console.Write(message);

        if (int.TryParse(Console.ReadLine(), out int number))
        {
            return number;
        }

        Console.WriteLine("Please enter a valid number.");
    }
}