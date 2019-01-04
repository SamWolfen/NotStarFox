using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControls : MonoBehaviour
{
    public GameObject Plane;
    public GameObject PlaneShell;
    public bool CanFire;
    public GameObject LaserPool;
    Rigidbody m_Rigidbody;
    int LaserPoolSize = 0;
    int LaserPoolCounter = 0;
    float Horizontal;
    float Vertical;
    float TranslateSpeed = 100;
    float RotateSpeed = 10;
    float HorizontalTrans;
    float HorizontalRotate;
    float VerticalTrans;
    float VerticalRotate;
    Vector3 MoveVelo;
    Vector3 scrubbedMove;
    Vector3 SmoothedRotate;
    float SmoothStep = 1f;
    float hLimit = 52;
    float vLimit = 30;
    float Boost = 1.5f;





    // Use this for initialization
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        LaserPoolSize = LaserPool.GetComponent<PoolGenerator>().PoolObjectList.Capacity;
        Debug.Log("Laser Pool Size: " + LaserPoolSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRING MAH LASER!!! " + LaserPool.GetComponent<PoolGenerator>().PoolObjectList[LaserPoolCounter].name);
            LaserPool.GetComponent<PoolGenerator>().PoolObjectList[LaserPoolCounter].SetActive(true);

            LaserPoolCounter++;

            if (LaserPoolCounter >= LaserPoolSize)
            {
                LaserPoolCounter = 0;
            }
        }



        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        HorizontalTrans = Horizontal * TranslateSpeed * Time.deltaTime;
        VerticalTrans = Vertical * TranslateSpeed * Time.deltaTime;
        HorizontalRotate = HorizontalTrans * RotateSpeed;
        VerticalRotate = VerticalTrans * RotateSpeed;

        if (Input.GetButton("Fire2"))
        {
            HorizontalTrans *= Boost;
            VerticalTrans *= Boost;
        }

        if ((transform.localPosition.x <= -52 && Horizontal < 0) || (transform.localPosition.x >= 52 && Horizontal > 0))
        {
            Debug.Log("Bounds");
            HorizontalTrans = 0;

        }

        if ((transform.localPosition.y <= -33 && -Vertical < 0) || (transform.localPosition.y >= 14 && -Vertical > 0))
        {
            Debug.Log("Bounds");
            VerticalTrans = 0;

        }



        //transform.Rotate(0, 0, Horizontal * RotateSpeed * Time.deltaTime);
        //transform.Translate(HorizontalTrans, -VerticalTrans, 0);
        //m_Rigidbody.velocity.Set(HorizontalTrans, -VerticalTrans, 0);

        MoveVelo = new Vector3(HorizontalTrans, -VerticalTrans, 0);
        //Debug.Log(m_Rigidbody.velocity);
        //m_Rigidbody.MovePosition(transform.position + MoveVelo);
        this.transform.Translate(MoveVelo);

        //smooth out rotation
        if (SmoothedRotate.x > VerticalRotate)
        {
            SmoothedRotate.x -= SmoothStep*2;
        }
        else if (SmoothedRotate.x < VerticalRotate)
        {
            SmoothedRotate.x += SmoothStep * 2;
        }

        if (SmoothedRotate.y > HorizontalRotate)
        {
            SmoothedRotate.y -= SmoothStep;

        }
        else if (SmoothedRotate.y < HorizontalRotate)
        {
            SmoothedRotate.y += SmoothStep;
        }
            

        if (SmoothedRotate.z > -HorizontalRotate)
        {
            SmoothedRotate.z -= SmoothStep;

        }
        else if (SmoothedRotate.z < -HorizontalRotate)
        {
            SmoothedRotate.z += SmoothStep;
        }


        PlaneShell.transform.localEulerAngles = SmoothedRotate;
       



    }
}
