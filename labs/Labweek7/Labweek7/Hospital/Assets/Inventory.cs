using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<GameObject> items = new List<GameObject>();
    public void AddItem(GameObject i)
    {
        items.Add(i);
    }
    public GameObject FindItemWithTag(string tag)
    {
        foreach (GameObject i in items)
        {
            if (i.CompareTag(tag))
            {
                return i;
            }
        }
        return null;
    }

    public void RemoveItems(GameObject _i)
    {
        int index = -1;
        foreach (GameObject i in items)
        {
            index++;
            if (i == _i)
                break;
        }
        if (index >= -1) items.RemoveAt(index);
    }
}
