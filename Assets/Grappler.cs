using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Rigidbody2D _rb;
    public float force = 5f;
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            EnableGrapple(true);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EnableGrapple(false);
        }

        if (_distanceJoint.enabled && _rb.velocity.magnitude < 0.5 && isColliding)
        {
            EnableGrapple(false);
            var direction = _rb.velocity.normalized;
            _rb.AddForce(direction * force, ForceMode2D.Impulse);
            //Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 direction = (mousePos - (Vector2)transform.position).normalized;
            //_rb.AddForce(direction * force, ForceMode2D.Impulse);
            //Debug.Log("push");
        }

        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }

    void EnableGrapple(bool enable)
    {
        _distanceJoint.enabled = enable;
        _lineRenderer.enabled = enable;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isColliding = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}
