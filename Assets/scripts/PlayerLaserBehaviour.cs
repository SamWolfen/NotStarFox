using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserBehaviour : MonoBehaviour {
    public GameObject Lasers;
    public GameObject Plane;
    Rigidbody m_Rigidbody;
    public float speed;
    Transform LocalZero;
    public float Lifetime;
    float initLifetime = 0;
    private void OnEnable()
    {
        Debug.Log("enabled");
        LocalZero = Plane.transform;
        Lasers.transform.position = LocalZero.position;
        Lasers.transform.rotation = LocalZero.rotation;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.velocity = transform.forward * speed;

    }

    // Use this for initialization
    void Start () {
        transform.position.Set(0.0f, 0.0f, 0.0f);
        initLifetime = Lifetime;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.velocity = transform.forward * speed;
    }

    private void Awake()
    {
        
    }

    

    // Update is called once per frame
    void Update () {
        if (Lifetime > 0)
        {
            Lifetime -= (Time.deltaTime); ;
        }
        else
        {
            Lifetime = initLifetime;
            gameObject.SetActive(false);
        }

        LocalZero = Plane.transform;
	}
}
