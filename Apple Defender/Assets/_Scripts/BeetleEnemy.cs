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

    //If health reaches 0, enemy is destroyed
    public void RemoveHealth()
    {
        health--;
        if (health <= 0)
        {
            ScoreManager.instance.Score += 30;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If enemy touches an apple, it steals it
        if (other.CompareTag("Apple"))
        {
            haveApple = true;
            speed = escapingSpeed;
            appleArt.SetActive(true);
            appleStack = other.gameObject.transform.parent.GetComponent<AppleStack>();
            appleStack.RemoveApple();
        }

        //If enemy reaches the left border with an apple, this enemy is destroyed, and the apple won't return to the stack
        if (other.CompareTag("End"))
        {
            if (haveApple)
            {
                haveApple = false;
                Destroy(gameObject);
            }
        }

        //If enemy collides with a bullet, it loses health
        if (other.CompareTag("Bullet"))
        {
            SoundManager.instance.PlayHitEnemySFX();
            RemoveHealth();            
            Destroy(other.gameObject);
        }

        //If enemy touches the right border, the game ends
        if (other.CompareTag("GameOver"))
        {
            SceneController.instance.InsectGameOver();
        }
    }

    //When enemy is destroyed, the apple returns to stack
    private void OnDestroy()
    {
        if (haveApple)
        {
            appleStack.AddApple();
        }
    }
}
