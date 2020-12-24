using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
