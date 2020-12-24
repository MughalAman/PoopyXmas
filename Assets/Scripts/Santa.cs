using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Santa : MonoBehaviour
{
    //Variables
    [SerializeField] private float speed = 0.5f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

}
