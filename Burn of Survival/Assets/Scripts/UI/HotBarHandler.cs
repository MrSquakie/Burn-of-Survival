using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarHandler : MonoBehaviour
{
    public Transform[] slot;
    public GameObject hotBarHolder;
    public void Start()
    {
        int numOfSlots = hotBarHolder.transform.childCount;
        slot = new Transform[numOfSlots];
        for (int i = 0; i < numOfSlots; i++)
        {
            slot[i] = hotBarHolder.transform.GetChild(i);
            print(slot[i].transform.name);
        }

    }
}
