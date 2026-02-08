using UnityEngine;
public class BallCollision : MonoBehaviour{
    public AudioSource hitSound;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("IncrementPoint"))
        {
            AudioManager.instance.Play("Point");
        }
        if (collider.CompareTag("SwapScores"))
        {
            AudioManager.instance.Play("SwappingScores");
        }
        if (collider.CompareTag("RandomSpeed"))
        {
            AudioManager.instance.Play("RandomSpeed");
        }
        if (collider.CompareTag("ReflectBall"))
        {
            AudioManager.instance.Play("BallReflection");
        }
    }
    
    void OnCollisionEnter(Collision collision){
        if(collision.collider.name == "PaddleL" || collision.collider.name == "PaddleR"){
            hitSound = AudioManager.instance.GetAudioSource("Ball_Paddle");
            if (hitSound != null)
            {
                hitSound.pitch += 0.5f;

                if (hitSound.pitch > 5f)
                {
                    hitSound.pitch = 5f;
                }

                hitSound.Play();
            }
            BallScript.FindFirstObjectByType<BallScript>().speed += 1f;
            AudioManager.instance.Play("Ball_Paddle");
        }
        if(collision.collider.name == "North" || collision.collider.name == "South"){
            BallScript.FindFirstObjectByType<BallScript>().speed += 1f;
        }
        if (collision.collider.name == "West"){
            BallScript.FindFirstObjectByType<BallScript>().player2Score++;
            Debug.Log("Player 2 has scored!");
            AudioManager.instance.Play("PT_Player2");
            BallScript.FindFirstObjectByType<BallScript>().ResetBall(-1);
        }
        if (collision.collider.name == "East"){
            BallScript.FindFirstObjectByType<BallScript>().player1Score++;
            Debug.Log("Player 1 has scored!");
            AudioManager.instance.Play("PT_Player1");
            BallScript.FindFirstObjectByType<BallScript>().ResetBall(1);
        }
        if(BallScript.FindFirstObjectByType<BallScript>().player1Score == 11){
            Debug.Log("Player 1 has won!");
            AudioManager.instance.Play("GO_Player1Wins");
            BallScript.FindFirstObjectByType<BallScript>().ResetGame();
        }
        if (BallScript.FindFirstObjectByType<BallScript>().player2Score == 11){
            Debug.Log("Player 2 has won!");
            AudioManager.instance.Play("GO_Player2Wins");
            BallScript.FindFirstObjectByType<BallScript>().ResetGame();
        }
    }
}