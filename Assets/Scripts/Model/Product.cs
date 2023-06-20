using UnityEngine;

public enum ProductType
{
    Fillet,
    Conserve,
    Frozen,
    Fresh
}

public class Product
{
    public string Name { get; private set; }
    public ProductType ProductType { get; private set; }

    public void SetProductType(ProductType productType)
    {
        ProductType = productType;
        Name = productType.ToString();
    }
}
