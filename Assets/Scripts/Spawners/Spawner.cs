using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // Prefab of object we want to spawn
    public float spawnRate = 1f; // Spawn an object every spawn rate interval (in seconds)
    [HideInInspector]
    public List<GameObject> objects = new List<GameObject>();
    private float spawnTimer = 0f; // Counts up every frame in seconds


    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    Vector3 GenerateRandomPoint()
    {
        //SET halfscale to half of transform's scale
        Vector3 halfScale = transform.localScale / 2;
        // SET random point to zero
        Vector3 randomPoint = Vector3.zero;
        // SET randomPoint x, y & z to random Range between
        randomPoint.x = Random.Range(-halfScale.x, halfScale.x);
        randomPoint.y = Random.Range(-halfScale.y, halfScale.y);
        randomPoint.z = Random.Range(-halfScale.z, halfScale.z);
        // -halfscale to halfscale to halfscale (HINT: can do individually)
        // RETURN randomPoint
        return randomPoint;
    }

    public void Spawn(Vector3 position, Quaternion rotation)
    {
        //SET Clone to new instance of prefab
        GameObject clone = Instantiate(prefab);
        // ADD Clone to objects
        objects.Add(clone);
        // SET clone's position to spawner's position + position
        clone.transform.position = transform.position + position;
        // SET Clone's rotation to rotation
        clone.transform.rotation = rotation;
    }


    // Update is called once per frame
    void Update()
    {
        // SET spawnTimer to spawnTimwe + delta time
        spawnTimer += Time.deltaTime;
        // IF spawnTimer > spawnRate
        if (spawnTimer > spawnRate)
        {
            // SET randomPoint to GenerateRandomPoint()
            Vector3 randomPoint = GenerateRandomPoint();
            // CALL Spawn() and pass randomPoint, Quaternion Identity
            Spawn(randomPoint, Quaternion.identity);
            // SET spawnTimer to zero
            spawnTimer = 0f;
        }
    }
}
