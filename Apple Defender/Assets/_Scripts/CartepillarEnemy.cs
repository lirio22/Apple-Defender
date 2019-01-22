using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartepillarEnemy : MonoBehaviour {
    
    //----Movement Variables----//
    private float speed = 1.5f;
    private float escapingSpeed = -0.5f;

    //-----Health Variables----//
    private int health = 1;

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
        if(health <= 0)
        {
            ScoreManager.instance.Score += 15;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se o inimigo encostar na maçã, ele a rouba
        if(other.CompareTag("Apple"))
        {
            haveApple = true;
            speed = escapingSpeed;
            appleArt.SetActive(true);
            appleStack = other.gameObject.transform.parent.GetComponent<AppleStack>();
            appleStack.RemoveApple();
        }

        if(other.CompareTag("End"))
        {
            if(haveApple)
            {
                haveApple = false;
                Destroy(gameObject);
            }
        }

        if(other.CompareTag("Bullet"))
        {
            SoundManager.instance.PlayHitEnemySFX();
            RemoveHealth();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("GameOver"))
        {
            SceneController.instance.InsectGameOver();
        }
    }

    private void OnDestroy()
    {
        if(haveApple)
        {
            appleStack.AddApple();                
        }
    }
}
