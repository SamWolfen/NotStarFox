using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RailFollower : MonoBehaviour
{
    public GameObject FirstNode;
    public GameObject CurrentNode;
    bool following;
    public float speed;
    public float baseSpeed;


    // Start is called before the first frame update
    void Start()
    {
        CurrentNode = FirstNode;
        Debug.Log("Following "+ CurrentNode.name);
        speed = baseSpeed * CurrentNode.GetComponent<NodeProperties>().speed;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentNode.transform.position, speed*Time.deltaTime);
        transform.LookAt(CurrentNode.transform.position, Vector3.up);
        speed = baseSpeed * CurrentNode.GetComponent<NodeProperties>().speed;
        //this.transform.Translate(Vector3.forward*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collided with " + collider.gameObject.name);


        if (collider.gameObject == CurrentNode)
        {
            CurrentNode = collider.gameObject.GetComponent<NodeProperties>().NextNode;
            //speed = baseSpeed * CurrentNode.GetComponent<NodeProperties>().speed;
        }
    }

}
