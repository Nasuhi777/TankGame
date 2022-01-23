using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health=100;
    private float damage = 20;
    public GameObject exp;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Instantiate(exp, transform.position, transform.rotation);
            GameObject go = GameObject.Find("Background_Health_Enemy");
            health -= damage;
            
            go.GetComponent<Image>().fillAmount = health / 100;
            /*
            GameObject exp= ExplosionPool.instance.GetPooledObject();
            if(exp!=null)
            {
                exp.SetActive(true);
                exp.transform.parent = col.transform;
            }
            */
        }
    }
   
    private void Update()
    {
        if (health < 1)
        {
            /*
            GameObject exp = ExplosionPool.instance.GetPooledObject();
            if (exp != null)
            {
                exp.SetActive(true);
            }
            */
            Instantiate(exp, transform.position, transform.rotation);
            GameObject go = GameObject.Find("GameManager");
            go.GetComponent<GameManager>().AddScore(300);
            //GameManager.instance.AddScore(50);
            Destroy(gameObject);
            
            
        }
            
    }
}
