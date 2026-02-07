using UnityEditor.Build.Content;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Paddle")
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            AudioManager.instance.Play("Ball_Hitting_Paddle");
        }
    }
}
