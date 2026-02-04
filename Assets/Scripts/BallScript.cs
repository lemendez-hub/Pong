using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 5f;
    Vector3 direction;
    private int player1Score;
    private int player2Score;
    public Vector3 spawnPoint;
    
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
        if(collision.gameObject.name == "West")
        {
            player2Score++;
            transform.position = spawnPoint;
        }
        if(collision.gameObject.name == "East")
        {
            player1Score++;
            transform.position = spawnPoint;
        }
    }
}