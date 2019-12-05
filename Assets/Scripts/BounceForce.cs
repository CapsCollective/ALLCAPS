using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceForce : MonoBehaviour
{

    public Rigidbody ballRigid;
    public float distanceThreshold;

    public float forceAmount = 100;

    public float upness = 5;
    public void ApplyForce (float influence)
    {
        float distToBall = Vector3.Distance(transform.position, ballRigid.transform.position);
        if (distToBall > distanceThreshold) return;

        Vector3 unitVector = (transform.position - (ballRigid.transform.position + new Vector3(0, upness, 0))).normalized;

        ballRigid.AddForce(influence * forceAmount * unitVector);

        //ballRigid.AddExplosionForce(unitVector * influence * forceAmount);
        // search for ball nearby
    }
}
