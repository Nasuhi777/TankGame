using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public float rotationSpeed=1;
    public float BlastPower = 15;

    public GameObject CannonBall;
    public Transform shotPoint;
    // public GameObject Explosion;
    public float health = 100;

    void Update()
    {
        /*
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VerticalRotation = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
            new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed));
        */

        if(Input.GetKeyDown(KeyCode.Space)|| Input.touchCount>1 && canShoot)
        {
            GameObject CreateCannonBall = Instantiate(CannonBall, shotPoint.position, shotPoint.rotation);
            canShoot = false;
            CreateCannonBall.GetComponent<Rigidbody>().velocity = shotPoint.transform.up * BlastPower;
            FindObjectOfType<AudioManager>().Play("Launch");
            StartCoroutine(ShootDelay());
        }
    }
    public bool canShoot=true;
    public float delayInSeconds;
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }

  

}
