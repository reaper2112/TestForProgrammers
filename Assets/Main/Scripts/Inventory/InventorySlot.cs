using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    //нужно приватить
    
    public ItemScriptableObject item;
    public int amount;
    public bool isEmpty = true;
    [SerializeField] public GameObject iconGO;
    [SerializeField] public TMP_Text itemAmountText;

    public void SetIcon(Sprite icon)
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }
}