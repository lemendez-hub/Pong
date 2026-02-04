using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 5f;

    Vector3 direction;

    void Start()
    {
        direction = new Vector3(1f, 0f, 1f);
    }

    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normalHit = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normalHit);
    }
}