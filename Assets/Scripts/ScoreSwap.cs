using UnityEngine;

public class ScoreSwap : MonoBehaviour
{
    public GameObject cubePrefab;
    public float seconds = 15f;
    public float maxSeconds = 7f;
    private float timer;
    
    void Start()
    {
        SpawnCube();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= seconds)
        {
            SpawnCube();
            timer = 0f;
        }
    }
    
    void SpawnCube()
    {
        float randomX = Random.Range(-40.0f, 40.0f);
        float randomZ = Random.Range(-20.0f, 20.0f);
        
        Vector3 spawn = new Vector3(randomX, 1f, randomZ);
        
        GameObject cube = Instantiate(cubePrefab, spawn, Quaternion.identity);
        Destroy(cube, maxSeconds);
    }
    
    void OnTriggerEnter(Collider other)
    {
        BallScript ballScript = other.gameObject.GetComponent<BallScript>();
        
        if (ballScript != null)
        {
            int tempScore = ballScript.player1Score;
            
            ballScript.player1Score = ballScript.player2Score;
            ballScript.player2Score = tempScore;
            
            
            Destroy(gameObject);
            Debug.Log("Scores have Swapped!");
        }
    }
}
