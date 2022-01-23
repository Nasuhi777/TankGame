using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    public GameObject exp;
    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Instantiate(exp,transform.position,transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ball")
        {
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Terrain")
        {
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        StartCoroutine(DestroyItself());
    }
    IEnumerator DestroyItself()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(gameObject);
    }
}

