﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour
{
    public float weighting = 7.5f;
    [HideInInspector]
    public AIAgent owner;

    // Use this for initialization
    void Awake()
    {
        owner = GetComponent<AIAgent>();
    }

    // Update is called once per frame
    public virtual Vector3 GetForce()
    {
        return Vector3.zero;
    }
}
