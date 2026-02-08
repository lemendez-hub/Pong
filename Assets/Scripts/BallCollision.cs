using UnityEngine;

public class BallCollision : MonoBehaviour{
    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Point_Addition")){
            AudioManager.instance.Play("Point");
        }
    }
    
    void OnCollisionEnter(Collision collision){
        if(collision.collider.name == "PaddleL" || collision.collider.name == "PaddleR"){
            BallScript.FindFirstObjectByType<BallScript>().speed += 2f;
            AudioManager.instance.Play("Ball_Hitting_Paddle");
        }
        if(collision.collider.name == "North" || collision.collider.name == "South"){
            BallScript.FindFirstObjectByType<BallScript>().speed += 0.5f;
        }
        if (collision.collider.name == "West"){
            BallScript.FindFirstObjectByType<BallScript>().player2Score++;
            Debug.Log("Player 2 has scored!");
            AudioManager.instance.Play("Point");
            BallScript.FindFirstObjectByType<BallScript>().ResetBall(-1);
        }
        if (collision.collider.name == "East"){
            BallScript.FindFirstObjectByType<BallScript>().player1Score++;
            Debug.Log("Player 1 has scored!");
            AudioManager.instance.Play("Point");
            BallScript.FindFirstObjectByType<BallScript>().ResetBall(1);
        }
        if(BallScript.FindFirstObjectByType<BallScript>().player1Score == 11){
            Debug.Log("Player 1 has won!");
            //AudioManager.instance.Play("GameOver_1_Wins");
            BallScript.FindFirstObjectByType<BallScript>().ResetGame();
        }
        if (BallScript.FindFirstObjectByType<BallScript>().player2Score == 11){
            Debug.Log("Player 2 has won!");
            //AudioManager.instance.Play("GameOver_2_Wins");
            BallScript.FindFirstObjectByType<BallScript>().ResetGame();
        }
    }
}