using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Thrust", 1.0f, 200.0f);
    }

    private void Thrust()
    {
        rb.AddForce(new Vector3(0, 10, 0) * 15, ForceMode.Impulse);
    }
}
