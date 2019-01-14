using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleEnemy : MonoBehaviour {
    
    //----Movement Variables----//
    private float speed = 2.0f;
    private float escapingSpeed = -1.0f;

    //-----Health Variables----//
    private int health = 1;

    //----Collider Variables----//
    public bool haveApple;

    private void Start()
    {
        speed = DifficultyManager.instance.beetleSpeed;
        escapingSpeed = DifficultyManager.instance.beetleEscapingSpeed;
        health = DifficultyManager.instance.beetleHealth;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    public void RemoveHealth()
    {
        health--;
        if(health <= 0)
        {
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
            //Mostrar gráfico de que tem maçã
            //Diminuir uma mação do monte
        }

        if(other.CompareTag("End"))
        {
            if(haveApple)
            {
                haveApple = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if(haveApple)
        {
            //Voltar a maçã pro monte
        }
    }
}
