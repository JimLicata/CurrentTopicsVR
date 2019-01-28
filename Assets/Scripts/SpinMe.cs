using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMe : MonoBehaviour {

    void Start()
    {
    }

    void Update()
    {
    }
    public void Spin()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddRelativeTorque(new Vector3(0.0f, 10.0f), ForceMode.Impulse);
    }
}
