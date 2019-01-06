using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour {
    Rigidbody m_Rigidbody;
    public GameObject BallRender; 
    int initLifetime;
    int Lifetime = 20;
    Vector3 Velo;
    Vector4 initColour;
    int hits = 10;
    bool flash;
    bool flashed;
    float flashTimes = 3;
    float flashProg = 0;
    float flashTimesCount = 0;
    float flashTimeStep = 5;


    // Use this for initialization
    void Start () {
        initLifetime = Lifetime;
        m_Rigidbody = GetComponent<Rigidbody>();
        Velo.z = -3 * Random.Range(5f, 20f);
        Velo.x = Random.Range(-4f, 4f);
        Velo.y = Random.Range(-4f, 4f);
        initColour = BallRender.GetComponent<Renderer>().material.color;
        m_Rigidbody.velocity = Velo;
    }
	
	// Update is called once per frame
	void Update () {
        if (flash)
        {
            flashProg += flashTimeStep * Time.deltaTime;

            

            if (flashProg >= 1)
            {
                BallRender.GetComponent<Renderer>().material.color = initColour;
                flash = false;
                flashProg = 0;
            }






            //needlessly complicated
            //if ((Mathf.Sin(flashProg) > 0.8 || Mathf.Sin(flashProg) < -0.8) && !flashed)
            //{
            //    flashed = true;
            //    //flash red
            //    BallRender.GetComponent<Renderer>().material.color = Color.red;

            //    flashTimesCount++;

            //    if(flashTimesCount >= flashTimes)
            //    {
            //        flash = false;
            //    }
            //}



            
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PLaser")
        {
            hits--;
            flash = true;
            Debug.Log("hit");
            collision.gameObject.SetActive(false);
            BallRender.GetComponent<Renderer>().material.color = Color.red;
            flashProg = 0;

            if (hits <= 0)
            {
                //die
                gameObject.SetActive(false);
            }
        }
    }
}
