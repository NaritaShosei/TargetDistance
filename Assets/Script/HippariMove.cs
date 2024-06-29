using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippariMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float power = 2.0f;
    private float maxPower = 5.0f;
    private Vector2 StartPos;
    private Vector2 EndPos;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        StartPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        EndPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 force = Vector2.ClampMagnitude((StartPos - EndPos), maxPower);
        _rb.AddForce(force * power, ForceMode2D.Impulse);
    }
}
