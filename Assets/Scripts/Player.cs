using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float m_velocity = 0f;
    private Rigidbody2D m_rb;

    private int m_points = 0;

    [SerializeField]
    private GameObject m_pointsTextInstance = null;
    private PointsRenderer m_pointsRenderer;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_rb.velocity = Vector2.one * m_velocity;
        m_pointsRenderer = m_pointsTextInstance.GetComponent<PointsRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_rb.velocity = Vector2.one * m_velocity;
            ++m_points;
        }

        float angle = Vector3.Angle(Vector3.right, m_rb.velocity);

        if (m_rb.velocity.y < 0)
        {
            angle = -angle;
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
        m_pointsRenderer.PointsSet(m_points);
    }

    private void OnCollisionEnter2D(Collision2D collision_)
    {
        GameManager.m_instance.RestartGame();
    }

    public int PointsGet()
    {
        return m_points;
    }
}
