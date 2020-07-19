using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float m_speed = 1.4f;

    private void Update()
    {
        transform.position += Vector3.left * m_speed * Time.deltaTime;
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}
