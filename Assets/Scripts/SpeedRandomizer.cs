using UnityEngine;

public class SpeedRandomizer : MonoBehaviour
{
    public GameObject ballPrefab;
    public float maxSpeed = 40f;
    public float minspeed = 1f;
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
        GameObject ball = Instantiate(ballPrefab, spawn, Quaternion.identity);
        Destroy(ball, maxSeconds);
    }

    void OnTriggerEnter(Collider other)
    {
        BallScript ballScript = other.gameObject.GetComponent<BallScript>();
        if (ballScript != null)
        {
            float randomSpeed = Random.Range(minspeed, maxSpeed);
            ballScript.speed = randomSpeed;
            Destroy(gameObject);
            Debug.Log("Ball speed has been randomized to: " + randomSpeed);
        }
        {
            
        }
    }
}