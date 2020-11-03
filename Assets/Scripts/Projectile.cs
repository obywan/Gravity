using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static List<Projectile> projectiles;

    private Rigidbody rb;
    private Vector3 startPos;

    public float Mass
    {
        get
        {
            return rb.mass;
        }
    }

    public Vector3 Pos
    {
        get
        {
            return transform.position;
        }
    }

    private void Awake()
    {
        if(projectiles == null)
        {
            projectiles = new List<Projectile>();
        }
    }

    private void OnEnable()
    {
        projectiles.Add(this);
    }

    private void OnDisable()
    {
        projectiles.Remove(this);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D))
        {
            AddForce(Vector3.left * 10f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            AddForce(Vector3.right * 10f);
        }
        if (Input.GetKey(KeyCode.R))
        {
            ResetPos();
        }
    }

    public void AddForce(Vector3 force)
    {
        rb.AddForce(force, ForceMode.Acceleration);
    }

    private void ResetPos()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPos;
    }
}
