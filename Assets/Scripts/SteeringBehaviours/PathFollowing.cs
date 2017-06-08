using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GGL;

public class PathFollowing : MonoBehaviour
{
    public Transform target;
    // Distance to currentNode
    public float nodeRadius = 5f;
    // Distance to end node
    public float targetDistance = 3f;
    private Graph graph;
    private int currentNode = 0;
    private bool isAtTarget = false;
    private List<Node> path;

    // Use this for initialization
    void Start()
    {
        // SET graph to FindObjectOfType Graph
        // IF graph is null
        if (graph == null)
        {  // CALL Debug.LogError() and pass an Error message
             // CALL Debug.Break() (pauses the editor)
        }
    }

    // Update is called once per frame
    void Updatepath()
    {
        // SET path to graph.FindPath() and pass Transform's position, target's position
        // SET currentNode to zero

    }

    #region SEEK
    // Special Version of Seek that takes into account thw node radius & target radius
    Vector3 Seek(Vector3 target)
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // SET desiredForce to target - transform's position
        // SET desiredForce.y to zero

        // SET distance to zero
        // IF isAtTarget is true. NOTE: This needs to be done in a ternaray operation
        // SET distance to targetRadius
        // ELSE
        // SET distance to nodeRadius

        // IF desiredForce's length is greater than distance
        // SET desiredForce to desiredForce.normalized * weighting
        //SET force to desiredForce - owner's velocity

        // RETURN
        return force;
    }
    #endregion


    #region GetForce
    public override Vector3 GetForce()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // IF path is not null AND path count is greater than zero
        // SET currentPos to path[CurrentNode] position
        // IF Vector3.Distance(transform's position, currentPos)
        // Increment currentNode
        // IF currentNode is greater than or equal to path.count
        // SET CurrentNode to oath.Count - `
        
        #region GIZMOS
        // SET prevposition to path[0].position
        // Foreach node in path
            // CALL GizmosGL.Adds[here() and pass node's position, graph's nodeRadius, Identify any color
            // CALL GizmosGL.AddLine() and pass prev, node's position, 0.1f, 0.1f, any color
            // SET prev to node's position
        #endregion

        // RETURN force
        return force;

    }

    #endregion

    void Update()
    {

    }
}
