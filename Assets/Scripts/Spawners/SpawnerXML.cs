using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

[RequireComponent(typeof(Spawner))]
public class SpawnerXML : MonoBehaviour
{
    // Contains data for each object spawned
    public class SpawnerData
    {
        public Vector3 position;
        public Quaternion rotation;

    }
    [XmlRoot]
    public class XMLContainer
    {
        [XmlArray]
        public SpawnerData[] data;

    }

    public string filename;

    private Spawner spawner;
    private string fullPath;

    private XMLContainer xmlContainer;

    void SaveToPath(string path)
    {
        // Create a serializer of type of XML Container
        XmlSerializer serializer = new XmlSerializer(typeof(XMLContainer));
        // Open a file stam at patch using Create file mode
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            // Serialize stream from xmlContainer
            serializer.Serialize(stream, xmlContainer);
        }

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
