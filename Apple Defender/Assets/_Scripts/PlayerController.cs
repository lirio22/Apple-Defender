using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //----Movement Variables----//
    private float speed = 2.0f;
    private bool facingRight = true;
    private Rigidbody2D rb;

    //----Stairs Variables----//
    private bool isClimbing;

    //----Fire Variables----//
    public GameObject bulletPrefab;
    public Transform bulletSpawnPosition;
    public AmmoManager ammoManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        Fire();
        Climb();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (facingRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                facingRight = false;
            }
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (!facingRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                facingRight = true;
            }
        }
    }

    private void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && ammoManager.CurrentAmmo > 0)
        {
            if (!facingRight)
            {
                Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.Euler(0, 0, 180f));
            }
            else
            {
                Instantiate(bulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
            }
            ammoManager.CurrentAmmo--;
            SoundManager.instance.PlayShotSFX();
        }
    }

    private void Climb()
    {
        if(isClimbing)
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AmmoCrate"))
        {
            SoundManager.instance.PlayGetAmmoSFX();
            ammoManager.ResetCurrentAmmo();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Stairs") && Input.GetKey(KeyCode.W))
        {
            isClimbing = true;
            rb.gravityScale = 0;
            rb.mass = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Stairs"))
        {
            isClimbing = false;
            rb.gravityScale = 1f;
            rb.mass = 1;
        }
    }
}
