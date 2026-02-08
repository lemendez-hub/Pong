using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour{
    public float speed = 10f;
    
    public Vector3 direction;
    
    public int player1Score;
    public int player2Score;
    
    public Vector3 spawnPoint;
    
    public Text player1Text;
    public Text player2Text;

    public Text beginning;
    
    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        AudioManager.instance.Play("Start");
        direction = new Vector3(1f, 0f, 1f);
    }
    
    void Update()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
        player1Text.text = player1Score.ToString();
        player1Text.color = Color.red;
        player2Text.text = player2Score.ToString();
        player2Text.color = Color.red;

        if(player1Score >= 4 && player1Score < 8)
        {
            player1Text.color = Color.yellow;
        }
        if(player1Score >= 8)
        {
            player1Text.color = Color.green;
        }
        if(player2Score >= 4 && player2Score < 8)
        {
            player2Text.color = Color.yellow;
        }
        if (player2Score >= 8)
        {
            player2Text.color = Color.green;
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normalHit = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normalHit);
    }

    public void ResetBall(int dir)
    {
        transform.position = spawnPoint;
        speed = 10f;

        if (BallCollision.FindFirstObjectByType<BallCollision>().hitSound != null)
        {
            BallCollision.FindFirstObjectByType<BallCollision>().hitSound.pitch = 1f;
        }
        float random = Random.Range(-1f, 1f);
        direction = new Vector3(dir, 0f, random);
    }
    
    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;

        ResetBall(1);
    }
}