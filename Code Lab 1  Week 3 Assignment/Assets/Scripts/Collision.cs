using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Basket") && gameObject.CompareTag("Fruit")) //if collided with basket and gameObject
                                                                                        //is fruit  
        {
            Debug.Log("Collided");
            GameManager.Instance.Score++; //will raise score
            Destroy(gameObject); //destroy fruit
        }

        if (collision.gameObject.CompareTag("Basket") && gameObject.CompareTag("Bomb")) //if it is bomb
        {
            GameManager.Instance.Score = 0; //reset score
            Destroy(gameObject); //destroy bomb
        }
    }
}
