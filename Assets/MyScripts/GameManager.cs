using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public float Score;
    public static GameManager instance;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("fon");
    }
    public void AddScore(float x)
    {
        Score += x;
        GameObject f = GameObject.Find("scoreFloat");
        f.GetComponent<TextMeshProUGUI>().text = Score.ToString();
    }
   
   
}
