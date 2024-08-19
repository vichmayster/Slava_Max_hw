using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hit : MonoBehaviour
{
    int counter = 0;
    Score health;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (counter == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            counter = 1;
        }
        else if (counter == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            counter = 2;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }
}
