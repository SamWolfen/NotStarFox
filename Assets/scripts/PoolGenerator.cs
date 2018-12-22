﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGenerator : MonoBehaviour {
    public GameObject Pool;
    public GameObject PoolObject;
    static int PoolSize = 100;
    public List<GameObject> PoolObjectList = new List<GameObject>(PoolSize);
    
    // Use this for initialization
    void Start () {
        int i = 0;

        while (i < PoolSize)
        {
            GameObject newPoolObject = Instantiate(PoolObject, transform);
            newPoolObject.SetActive(false);
            PoolObjectList.Add(newPoolObject);

            i++;
        }

        Debug.Log(Pool.name + " Complete, list size: " + PoolObjectList.Capacity);
    }
	
	
}
