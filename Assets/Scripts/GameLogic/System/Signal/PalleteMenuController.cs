using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PalleteMenuController : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/12/28)
    /// </summary>
    [SerializeField] GameObject menu;
    [SerializeField] private RectTransform cursor;
    [SerializeField] Vector3 cursorOffsetRotation;
    [SerializeField] Vector3 cursorOffsetPosition;
    private Vector3 cursorAngle;
    [SerializeField] private List<ItemSlot> itemSlots = new List<ItemSlot>();
    [SerializeField] private float radius = 20f;
    private Vector2 mouseOriginPos;
    private float slotAngle;
    [SerializeField] UnityEvent<int> onSlotSelected = new();
    [SerializeField] UnityEvent onSlotNotSelecting = new();
    [SerializeField] UnityEvent onSlotSelecting = new();
    [SerializeField] UnityEvent onMenuOpened = new();
    [SerializeField] UnityEvent onMenuClosed = new();
    private ItemName selectedItem = ItemName.None;
    private ItemSlot selectedSlot;
    public void OpenMenu()
    {
        onMenuOpened.Invoke();
    }
    public void CloseMenu()
    {
        onMenuClosed.Invoke();
    }
    public void InitMenuLayout()
    {
        menu.transform.position = Input.mousePosition;
        slotAngle = 360f / itemSlots.Count;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            float angle = slotAngle * i + 120f;
            itemSlots[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;
        }
    }
    public void SetMousePosition()
    {
        mouseOriginPos = Input.mousePosition;
    }
    public void SetCursor()
    {
        cursorAngle = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - new Vector3(mouseOriginPos.x, mouseOriginPos.y, 0f)).eulerAngles;
        cursor.eulerAngles = cursorAngle + cursorOffsetRotation;
    }
    public void SetSelectedSlot()
    {
        float currentIndex = cursorAngle.z / slotAngle;
        if (currentIndex >= itemSlots.Count) currentIndex = 0;
        selectedSlot = itemSlots[(int)currentIndex];
        selectedItem = selectedSlot.itemName;
    }
    public void SelectingSlot()
    {
        if ((Input.mousePosition - new Vector3(mouseOriginPos.x, mouseOriginPos.y, 0f)).magnitude < radius * 0.5f)
        {
            selectedItem = ItemName.None;
            onSlotNotSelecting.Invoke();
        }
        else
        {
            onSlotSelecting.Invoke();
        }
    }
    public void SelectSlot()
    {
        if (selectedItem == ItemName.None)
            return;
        onSlotSelected.Invoke((int)selectedItem);
    }
}
