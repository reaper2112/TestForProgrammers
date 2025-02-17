using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // нужно приватить дистанцию 
    public AddItems itemAdder;
    public GameObject _UIPanel;
    public Transform _inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public float reachDistance = 10.0f; // дистанция чтобы дотянуться до item
    public bool _isOpen;
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        _UIPanel.SetActive(true);
    }

    private void Start()
    {
        itemAdder = GetComponent<AddItems>();
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
                    ItemScriptableObject itemToAdd = hit.collider.gameObject.GetComponent<Item>().item;
                    int amountToAdd = hit.collider.gameObject.GetComponent<Item>().amount;
                    itemAdder.AddItem(itemToAdd, amountToAdd, slots);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    
}
