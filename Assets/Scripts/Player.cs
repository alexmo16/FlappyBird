using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float m_velocity = 0f;
    private Rigidbody2D m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_rb.velocity = Vector2.one * m_velocity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_rb.velocity = Vector2.one * m_velocity;
        }

        float angle = Vector3.Angle(Vector3.right, m_rb.velocity);

        if (m_rb.velocity.y < 0)
        {
            angle = -angle;
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision_)
    {
        GameManager.m_instance.RestartGame();
    }
}
