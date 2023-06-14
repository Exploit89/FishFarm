using UnityEngine;

public enum ProductType
{
    Fillet,
    Conserve,
    Frozen,
    Fresh
}

public class Product : MonoBehaviour
{
    public ProductType ProductType { get; private set; }

    public void SetProductType(ProductType productType)
    {
        ProductType = productType;
    }
}
