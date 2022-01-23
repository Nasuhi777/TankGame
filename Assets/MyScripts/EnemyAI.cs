using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject projectile;
    public GameObject shotPoint;
    public float BlastPower=5;
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        float distance = player.transform.position.x - transform.position.x;
        float x=Mathf.Abs(distance);
        if(x<50 && canShoot)
        {
           Shoot();
            canShoot = false;
            
        }
        if (x < 40)
            MovePad(50);
        else
            MovePad(-50);


        if (x < 5)
        {
            Debug.Log("5");
            BlastPower = 2.5f;
        }
        else if (x < 10)
        {
            Debug.Log("10");
            BlastPower = 5;
        }
        else if(x<20)
        {
            Debug.Log("20");
            BlastPower = 27;
        }
            
        else if(x<30)
        {
           Debug.Log("30");
            BlastPower = 50;

        }
            
        else if (x < 40)
        {
            Debug.Log("40");
            BlastPower = 60;
        }
        else if (x < 50)
        {
            Debug.Log("50");
            BlastPower = 70;
        }


    }

    void Shoot()
    {

        GameObject CreateCannonBall = Instantiate(projectile, shotPoint.transform.position,transform.rotation);
        CreateCannonBall.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * BlastPower;
        StartCoroutine(ShootDelay());
    }
    public bool canShoot = true;
    public float delayInSeconds;
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }
    public void MovePad(float x)
    {

        GameObject go = this.gameObject;
        if (go != null)
        {
            Vector3 pos = go.transform.position;
            pos.x += x * Time.deltaTime * 0.1f;
            //pos.y = 0;
            go.transform.position = pos;
        }
        else
            Debug.Log("Player is null");


    }


}
