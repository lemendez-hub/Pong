using UnityEngine;
using UnityEngine.AI;
public class PaddleAI : MonoBehaviour
{
    public Transform ball;
    public float speed = 25f;

    void Update()
    {
        if (ball == null)
            return;

        float direction = 0f;

        if (ball.position.z > transform.position.z)
        {
            direction = 1f;
        }
        else if (ball.position.z < transform.position.z)
        {
            direction = -1f;
        }

        transform.position += new Vector3(0f, 0f, direction * speed * Time.deltaTime);
    }

}
