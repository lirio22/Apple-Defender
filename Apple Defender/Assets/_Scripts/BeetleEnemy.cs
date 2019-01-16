using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnemy : MonoBehaviour {

    //----Movement Variables----//
    private float speed = 1.5f;
    private float escapingSpeed = -0.5f;

    //-----Health Variables----//
    private int health = 2;

    //----Collider Variables----//
    public bool haveApple;

    //----Apple Variables----//
    public GameObject appleArt;
    private AppleStack appleStack;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    public void RemoveHealth()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se o inimigo encostar na maçã, ele a rouba
        if (other.CompareTag("Apple"))
        {
            haveApple = true;
            speed = escapingSpeed;
            appleArt.SetActive(true);
            appleStack = other.gameObject.transform.parent.GetComponent<AppleStack>();
            appleStack.RemoveApple();
        }

        if (other.CompareTag("End"))
        {
            if (haveApple)
            {
                haveApple = false;
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Bullet"))
        {
            RemoveHealth();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("GameOver"))
        {
            //Chamar o GameOver
        }
    }

    private void OnDestroy()
    {
        if (haveApple)
        {
            appleStack.AddApple();
        }
    }
}
