using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public Rigidbody projectile;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public LineRenderer lineVisual;
    public int lineSegment=10;


    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
        lineVisual.positionCount = lineSegment;
    }
    void Update()
    {
        LaunchProjectile();
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 1 && canShoot)
        {
            LaunchProjectile();
            
        }
    }
    public bool canShoot = true;
    public float delayInSeconds;
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        canShoot = true;
    }
    void LaunchProjectile()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

            Ray camRay = cam.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(camRay, out hit, 100f, layer))
            {
                cursor.SetActive(true);
                cursor.transform.position = hit.point + Vector3.up * 0.1f;
                //Debug.Log("1");

                Vector3 vo = CalculateVeclocity(hit.point, shootPoint.position, 1f);
                Visualize(vo);

                transform.rotation = Quaternion.LookRotation(vo);
                if (canShoot && Input.touchCount == 1 && hit.transform.gameObject.tag=="Enemy")
                {
                    //  Debug.Log("2");

                    Rigidbody obj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
                    canShoot = false;

                    FindObjectOfType<AudioManager>().Play("Launch");
                    StartCoroutine(ShootDelay());
                    obj.velocity = vo;

                }
            }
        }
    }

    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo,i/(float)lineSegment);
            lineVisual.SetPosition(i,pos);

        }
    }
    Vector3 CalculateVeclocity(Vector3 target,Vector3 origin,float time)
    {
        Vector3 distance=target- origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0;

        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
    Vector3 CalculatePosInTime(Vector3 vo,float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0;
       
        Vector3 result = shootPoint.position + vo * time;
        float sY=(-0.5f*Mathf.Abs(Physics.gravity.y)*(time*time))+(vo.y*time)+shootPoint.position.y;
        result.y = sY;

        return result;
    }
}
