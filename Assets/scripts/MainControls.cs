using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControls : MonoBehaviour {
    public GameObject Plane;
    public bool CanFire;
    public GameObject LaserPool;
    int LaserPoolSize = 0;
    int LaserPoolCounter = 0;
    
    


	// Use this for initialization
	void Start () {

        LaserPoolSize = LaserPool.GetComponent<PoolGenerator>().PoolObjectList.Capacity;


       



	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.anyKeyDown)
        {
            LaserPool.GetComponent<PoolGenerator>().PoolObjectList[LaserPoolCounter].SetActive(true);
            LaserPoolCounter++;

            if (LaserPoolCounter >= LaserPoolSize)
            {
                LaserPoolCounter = 0;
            }
        }
        



	}
}
