using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 3;
    float selfDestroyTime = 3f;
    Vector3 direction;
    void Start()
    {
        Destroy(gameObject, selfDestroyTime);
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    void FixedUpdate()
    {
        transform.position += direction * speed * Time.deltaTime;
        speed += 1f;

        Collider[] targets = Physics.OverlapSphere(transform.position, 0.25f);
        foreach (var item in targets)
        {
            if (item.tag == "Enemy")
            {
                Destroy(item.gameObject);
                PlayerController.enemyDestroyed++;
              
                Destroy(gameObject);
            }
        }
    }
}
