using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tank;
    public bool once = true;
    void Start()
    {
         
    }

  
    void Update()
    {
        
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        if (go.Length < 1 && once)
            Spawn();
    }
    void Spawn()
    {
        GameObject f = GameObject.Find("Player");
        if(f!=null)
        {
            Vector3 rotDeg = transform.eulerAngles + new Vector3(0, 180, 0);
            Instantiate(Tank,f.transform.position+new Vector3(90,0,0),Quaternion.Euler(rotDeg));
            once = false;
            StartCoroutine(SpawnTimer(3));
        }
        

    }
    IEnumerator SpawnTimer(float x)
    {
        yield return new WaitForSeconds(x);
        once = true;
    }
}
