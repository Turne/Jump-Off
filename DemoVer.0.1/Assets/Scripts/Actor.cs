using System;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private int value = 1000;

    public void Print()
    {
        Debug.Log("Print1111 " + value.ToString() + " Hash " + GetHashCode());
    }

    public void PrintGameObject()
    {
        if (this == null)
        {
            Debug.Log("PrintGameObject ");
            return;
        }

        Debug.Log("Go Name " + gameObject.name);
    }

    public void PrintName()
    {
        if (this == null)
        {
            Debug.Log("PrintName ");
            return;
        }

        Debug.Log("Name " + name);
    }
}
