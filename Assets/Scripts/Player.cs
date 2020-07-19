using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float m_velocity = 0f;
    private Vector2 m_velocityVector = new Vector2(0, 1);
    private Vector3 m_angleVector;

    private Rigidbody2D m_rb;

    private int m_points = 0;

    [SerializeField]
    private GameObject m_pointsTextInstance = null;
    private PointsRenderer m_pointsRenderer;

    private Animator m_animator;

    public int PointsGet()
    {
        return m_points;
    }

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_rb.velocity = m_velocityVector * m_velocity;
        m_angleVector = Vector3.one * m_velocity;
        m_pointsRenderer = m_pointsTextInstance.GetComponent<PointsRenderer>();
        m_pointsRenderer.PointsSet(m_points);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_rb.velocity = m_velocityVector * m_velocity;
            m_angleVector = Vector3.one * m_velocity;
            m_animator.SetTrigger("PlayerFly");
        }
        else
        {
            m_angleVector += Physics.gravity * Time.deltaTime;
        }

        float angle = Vector3.Angle(Vector3.right, m_angleVector);
        if (m_angleVector.y < 0)
        {
           angle = -angle;
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision_)
    {
        GameManager.m_instance.RestartGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++m_points;
        m_pointsRenderer.PointsSet(m_points);
    }
}
