using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAi : MonoBehaviour
{
    public float range, aimTime, fireRate, shotsPerBurst;
    float aimTimer;
    bool firing;
    public GameObject playerObject;
    public GameObject laserPool;
    bool debug = true;

    int LaserPoolCounter;




    // Start is called before the first frame update
    void Start()
    {
        firing = false;
        LaserPoolCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (checkRange())
        {
            aimTimer+= Time.deltaTime;

            this.gameObject.transform.LookAt(playerObject.transform);

            if ((aimTimer>aimTime) && (firing == false))
            {
                firing = true;
                StartCoroutine(BurstFire());
                Debug.DrawLine(gameObject.transform.position, playerObject.transform.position, Color.red, 0.1f);
            }
            else
            {
                Debug.DrawLine(gameObject.transform.position, playerObject.transform.position, Color.white, 0.1f);
            }
        }
        else
        {
            aimTimer = 0;
        }
    }

    bool checkRange()
    {
        if (checkPlayerDist()<range)
        {
            return true;
        }

        return false;
    }

    float checkPlayerDist()
    {
        return Vector3.Distance(this.gameObject.transform.position, playerObject.transform.position);
    }

    IEnumerator BurstFire()
    {
        int shotCount = 0;

        while (shotCount<shotsPerBurst)
        {
            Debug.Log("shots" + shotCount);
            Fire();
            shotCount++;
            yield return new WaitForSeconds (1/fireRate);
        }
        yield return new WaitForSeconds(1);
        aimTimer = 0;
        firing = false;
    }


    void Fire()
    {
        Debug.Log("turret fire");

        laserPool.GetComponent<PoolGenerator>().PoolObjectList[LaserPoolCounter].SetActive(true);

        LaserPoolCounter++;

        if (LaserPoolCounter >= 10)
        {
            LaserPoolCounter = 0;
        }
    }

}
