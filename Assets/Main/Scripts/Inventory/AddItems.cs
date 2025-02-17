using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class AddItems : MonoBehaviour
{
    public void AddItem(ItemScriptableObject _item, int _amount, List<InventorySlot> slots)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == _item)
            {
                if (slot.amount + _amount <= _item._maximumAmount)
                {
                    slot.amount += _amount;
                    slot.itemAmountText.text = slot.amount.ToString();
                    return;
                }
                Debug.Log("Item found, increasing amount to " + slot.amount);
                break;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            if (slot.isEmpty == true)
            {
                slot.item = _item;
                slot.amount = _amount;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                slot.itemAmountText.text = _amount.ToString();
                Debug.Log("Empty slot found, adding item " + _item.name);
                break;
            }
        }

        Debug.Log("No empty slots found!");
    }
}
