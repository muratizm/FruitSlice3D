using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    private string[] slotNames;
    public GameObject[] goalSlots;

    private void Start()
    {
        slotNames = new string[isFull.Length];
    }
    public string[] getSlotNames()
    {
        return slotNames;
    }

    public void setSlotNames(int index, string name)
    {
        slotNames[index] = name;
    }

    public void resetNames()
    {
        for (int i = 0; i < slotNames.Length; i++)
        {
            slotNames[i] = " ";
        }
    }
}
