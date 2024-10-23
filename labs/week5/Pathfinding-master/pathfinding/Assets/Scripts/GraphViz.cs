using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphViz : MonoBehaviour
{
    GameObject[] nodes;
    List<Vector3> links;
    List<Vector3> from_pos;
    public float threshold = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        int numElements = this.transform.childCount;
        nodes = new GameObject[numElements];
        links = new List<Vector3>();
        from_pos = new List<Vector3>();
        for (int i=0; i<numElements; i++)
        {
            nodes[i] = this.transform.GetChild(i).gameObject;
        }
        foreach (GameObject node1 in nodes)
        {
            foreach (GameObject node2 in nodes)
            {
                if (node1 == node2) continue;
                float dist = Vector3.Distance(node1.transform.position, node2.transform.position);
                if (dist < threshold)
                {
                    Vector3 edge = node2.transform.position - node1.transform.position;
                    bool cliff = false;
                    int steps = Mathf.FloorToInt(edge.magnitude);
                    for (int i = 0; i< steps; i++)
                    {
                        Vector3 pos = node1.transform.position + edge.normalized * i;
                        RaycastHit hit;
                        if(Physics.Raycast(pos, Vector3.down, out hit, threshold))
                        {
                            if (hit.distance > 1.0f) cliff = true;
                        }
                    }
                    if(!Physics.Raycast(node1.transform.position, edge, threshold) && !cliff)
                    {
                        links.Add(edge);
                        from_pos.Add(node1.transform.position);
                    }
                }
            
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach(Vector3 link in links)
        {
            Debug.DrawLine(from_pos[i], from_pos[i] + link, Color.red);
            i++;
        }
    }
}
