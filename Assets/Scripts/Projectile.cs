using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    public void ChangePosition(Vector3 newPos)
    {
        thisRigidbody.isKinematic = true;
        transform.position = newPos;
        thisRigidbody.isKinematic = false;
    }
}
