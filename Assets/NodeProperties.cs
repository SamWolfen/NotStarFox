using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeProperties : MonoBehaviour
{
    public int MyID;
    public GameObject NextNode;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
