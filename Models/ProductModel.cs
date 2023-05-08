﻿namespace VendingMachine.Bee;

public class ProductModel
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }

    public override string ToString()
    {
        return $"Productnaam: {Name}\tProductprijs: {Price}";
    }
}
