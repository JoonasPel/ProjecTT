using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [Tooltip("Disable object after float x seconds.")]
    public float disableAfter = 5.0f;
    Rigidbody rb;

    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        Launch();
        Invoke("Disabler", disableAfter);
    }

    private void Launch()
    {
        rb.velocity = transform.TransformDirection(0, 0, speed);
    }

    private void Disabler()
    {
        rb.velocity = new Vector3(0, 0, 0);
        gameObject.SetActive(false);
    }
}
