using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviours
{
    public Transform target;
    public float stoppingDistance = 5f;

    public override Vector3 GetForce()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // IF target is null
        if(target == null)
        {
            return force;
        }

        // Direction = target position - owner's position
        Vector3 desiredForce = target.position - owner.transform.position;

        desiredForce.y = 0;

        if (desiredForce.magnitude > stoppingDistance)
        {
            desiredForce = desiredForce.normalized * weighting;
            // SET desiredForce to desiredForce normalized x weighting
            force = desiredForce - owner.velocity;
            // SET force to desiredForce - owner's velocity
        }
        // RETURN force
        return force;
    }

}
