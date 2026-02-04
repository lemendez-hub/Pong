using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public float speed = 5f;
    Vector3 direction;
    private int player1Score;
    private int player2Score;
    public Vector3 spawnPoint;
    public Text player1Text;
    public Text player2Text; 
    
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        direction = new Vector3(1f, 0f, 1f);
    }
    
    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
        player1Text.text = player1Score.ToString();
        player2Text.text = player2Score.ToString();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Vector3 normalHit = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normalHit);
        
        if(collision.gameObject.name == "West")
        {
            player2Score++;
            ResetBall();
        }
        if(collision.gameObject.name == "East")
        {
            player1Score++;
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = spawnPoint;
        direction = new Vector3(1f, 0f, 1f);
    }
}