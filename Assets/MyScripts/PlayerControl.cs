using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    private void Update()
    {
        ControlPad();
        //ControlPc();
    }
    public void ControlPad()
    {
        if (Input.touchCount > 0)
        {
            int i = 0;
            for (i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.position.x < Screen.width / 2)
                {
                    if (touch.phase != TouchPhase.Ended && Input.touchCount>1)
                    {
                       MovePad(-moveSpeed);
                      //  Debug.Log("endedleft");
                    }
                    else
                    {
                        //MovePad(-moveSpeed);
                        Debug.Log("left");
                    }

                }
                if (touch.position.x > Screen.width / 2 && Input.touchCount > 1)
                {
                 
                    if (touch.phase != TouchPhase.Ended)
                    {
                        MovePad(moveSpeed);
                       // Debug.Log("endedright");
                    }
                    else
                    {
                       // MovePad(moveSpeed);
                       // Debug.Log("right");
                    }

                }

            }
        }
        else
        {
            //holdingRight = false;
            // holdingLeft = false;
        }


    }
    void ControlPc()
    {
      
        if (Input.GetKey(KeyCode.A))
        {
            
            MovePad(-moveSpeed);
        }
       if (Input.GetKey(KeyCode.D))
        {
            
                MovePad(moveSpeed);
        }
    }
    public void MovePad(float x)
    {
        
        GameObject go = GameObject.Find("Player");
        if (go != null)
        {
            Vector3 pos = go.transform.position;
            pos.x += x*Time.deltaTime*0.1f;
            //pos.y = 0;
            go.transform.position = pos;
        }
        else
            Debug.Log("Player is null");
       

    }
    public float health = 100;
    private float damage = 10;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemyBall")
        {
            GameObject go = GameObject.Find("Background_Health");
            health -= damage;
            go.GetComponent<Image>().fillAmount = health / 500;
        }
    }
}
