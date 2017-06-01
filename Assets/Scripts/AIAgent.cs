using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public Vector3 force;
    public Vector3 velocity;
    public float maxVeocity = 100f;

    private SteeringBehaviours[] behaviours;
    // Use this for initialization
    void Start()
    {
        behaviours = GetComponents<SteeringBehaviours>();
    }

    // Update is called once per frame
    void Update()
    {
        ComputerForces();
        ApplyVelocity();
    }

    void ComputerForces()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        //FOR i = 0 to behaviours Count
        for (int i = 0; i < behaviours.Length; i++)
        {
            SteeringBehaviours behaviour = behaviours[1];
            //IF behaviour is not enabled
            if (!behaviour.enabled)
            {
                //Continue
                continue;
            }
            //SET fore to force + bahaviour's force
            force += behaviour.GetForce();
            //IF force is greater than max Velcity
            if (force.magnitude > maxVeocity)
            {
                //SET force to force normalized x maxVelocity
                force = force.normalized * maxVeocity;
                //BREAK
                break;
            }
        }
    }

    void ApplyVelocity()
    {
        // SET velocity to velocity + force x delta toimt
        velocity += force * Time.deltaTime;
        // IF ve;ocity is greaterthan maxVelocity
        if (velocity.magnitude > maxVeocity)
        {
            //SET velocity to velocity normalized x maxVelocity
            velocity = velocity.normalized * maxVeocity;
        }
        // If velocity os greater than zero
        if (velocity != Vector3.zero)
        {
            //Set position + velocity x delta time
            transform.position += velocity * Time.deltaTime;
            //SET rotation to Quaternion.LookRotation velocuty
            transform.rotation = Quaternion.LookRotation(velocity);
        }

    }
}
