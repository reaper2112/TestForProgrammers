using UnityEngine;

[CreateAssetMenu(fileName = "Shield Item", menuName = "Inventory/Items/New Shield Item")]

public class ShieldItem : ItemScriptableObject
{
    [SerializeField] private float defense;

    private void Start()
    {
        itemType = ItemType.Shield;
    }
}
