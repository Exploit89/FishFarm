using System.Collections;
using System.Collections.Generic;
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
}
