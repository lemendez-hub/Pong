using UnityEngine;

public class Score_Addition : MonoBehaviour
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
            if(ballScript.direction.x > 0)
            {
                ballScript.player1Score++;
                Destroy(gameObject);
                Debug.Log("Player 1 has been awarded a point!");
            }
            else if(ballScript.direction.x < 0)
            {
                ballScript.player2Score++;
                Destroy(gameObject);
                Debug.Log("Player 2 has been awarded a point!");
            }            
        }
    }
}
