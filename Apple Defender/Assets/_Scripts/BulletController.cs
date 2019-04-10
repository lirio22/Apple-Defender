using UnityEngine;

public class BulletController : MonoBehaviour {
    private float speed = 6.0f;

    private void Start()
    {
        Destroy(gameObject, 3.0f);
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
