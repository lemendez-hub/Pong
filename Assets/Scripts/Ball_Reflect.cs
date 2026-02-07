using UnityEngine;

public class Ball_Reflect : MonoBehaviour
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

        if(timer >= seconds)
        {
            SpawnCube();
            timer = 0f;
        }
    }

    void SpawnCube()
    {
        float randomX = Random.Range(-22.0f, 22.0f);
        float randomZ = Random.Range(-20.0f, 20.0f);
        Vector3 spawn = new Vector3(randomX, 1f, randomZ);
        GameObject cube = Instantiate(cubePrefab, spawn, Quaternion.identity);
        Destroy(cube, maxSeconds);
    }
}
