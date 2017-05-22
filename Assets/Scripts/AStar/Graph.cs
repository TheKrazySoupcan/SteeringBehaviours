using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public float nodeRadius = 1f;
    public LayerMask unwalkableMask;
    public List<Node> path;
    public Node[,] nodes;

    private float nodeDiameter;
    private int gridSizeX, gridSizeZ;
    private Vector3 scale;
    private Vector3 halfScale;

    // Use this for initialization
    void Start()
    {
        CreateGrid();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
        if(nodes != null)
        {
            for(int x = 0; x < nodes.GetLength(0); x++)
            {
                for(int z = 0; z < nodes.GetLength(1); z++)
                {
                    Node node = nodes[x, z];

                    Gizmos.color = node.walkable ? new Color(0, 0, 1, 0.5f) : new Color(1, 0, 0, 0.5f);

                    Gizmos.DrawSphere(node.position, nodeRadius);
                }

            }

        }

    }

    // Generates a 2D grid on the X and Z axis
    public void CreateGrid()
    {
        //calculate the node diameter
        nodeDiameter = nodeRadius * 2f;
        // Get transform's scale
        scale = transform.localScale;
        //half the scale
        halfScale = scale / 2f;
        gridSizeX = Mathf.RoundToInt(scale.x / nodeDiameter);
        gridSizeZ = Mathf.RoundToInt(scale.z / nodeDiameter);

        nodes = new Node[gridSizeX, gridSizeZ];

        Vector3 bottomLeft = transform.position - Vector3.right * halfScale.x - Vector3.forward * halfScale.z;

        for (int x = 0; x < gridSizeX; x++)
        {
            for(int z = 0; z < gridSizeZ; z++)
            {
                float xOffset = x * nodeDiameter + nodeRadius;
                float zOffset = z * nodeDiameter + nodeRadius;

                Vector3 nodePoint = bottomLeft + Vector3.right * xOffset + Vector3.forward * zOffset;
                bool walkable = !Physics.CheckSphere(nodePoint, nodeRadius, unwalkableMask);
                nodes[x, z] = new Node(walkable, nodePoint, x, z);
            }
        }
                                                    
    }

    public Node GetNodeFromPosition(Vector3 position)
    {
        float percentX = (position.x + halfScale.x) / scale.x;
        float percentZ = (position.z + halfScale.z) / scale.z;

        percentX = Mathf.Clamp01(percentX);
        percentZ = Mathf.Clamp01(percentZ);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int z = Mathf.RoundToInt((gridSizeZ - 1) * percentZ);

        return nodes[x, z];
    }

    // Update is called once per frame
    void Update()
    {
        CheckWalkables();
    }

    void CheckWalkables()
    {
        for(int x = 0; x < nodes.GetLength(0); x++)
        {
            for(int z = 0; z < nodes.GetLength(1); z++)
            {
                Node node = nodes[x, z];

                node.walkable = !Physics.CheckSphere(node.position, nodeRadius, unwalkableMask);
            }

        }


    }
    public List<Node> GetNeighbours(Node node)
    {

        List<Node> neighbours = new List<Node>();

        for(int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (x == 0 && z == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkZ = node.gridZ + z;
                if(checkX >= 0 &&
                    checkX < gridSizeX &&
                    checkZ >= 0 &&
                    checkZ < gridSizeZ)
                {
                    neighbours.Add(nodes[checkX, checkZ]);
                }
            }
        }
        return neighbours;
    }


}

