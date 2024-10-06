using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseMovement : MonoBehaviour
{
    Transform target;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target.transform.position,moveSpeed);
    }
}
