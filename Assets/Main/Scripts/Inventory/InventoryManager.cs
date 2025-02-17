using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // нужно приватить дистанцию 

    public GameObject _UIPanel;
    public Transform _inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public float reachDistance = 10.0f; // дистанция чтобы дотянуться до item
    public bool _isOpen;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private CinemachineVirtualCamera CVC;

    private void Awake()
    {
        _UIPanel.SetActive(true);
    }

    private void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < _inventoryPanel.childCount; i++)
        {
            if (_inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(_inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        _UIPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _isOpen = !_isOpen;
            if (_isOpen)
            {
                _UIPanel.SetActive(true);
            }
            else
            {
                _UIPanel.SetActive(false);
            }
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // заменить камеру на персонажа (подбирать по области вхождения)
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, reachDistance))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item, hit.collider.gameObject.GetComponent<Item>().amount);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void AddItem(ItemScriptableObject _item, int _amount)
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
