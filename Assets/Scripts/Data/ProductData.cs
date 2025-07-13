using UnityEngine;

public enum ProductCategory
{
    Shelf,
    Cooler
}

[CreateAssetMenu(fileName = "NewProduct", menuName = "Product/Create New Product")]
public class ProductData : ScriptableObject
{
    public string productName;
    public ProductCategory category;
    public Sprite icon;               
    public GameObject modelPrefab;   
}
