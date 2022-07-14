using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DiceTransformMethod : MonoBehaviour
{
    public int selectedResult;
    public Transform[] highestPoint;
    public Vector3[] diceNormals;
    private MeshFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        diceNormals = CalcNormals(filter.mesh);
    }

    private Vector3[] CalcNormals(Mesh mesh)
    {
        /*Vector3[] meshUnfiltered = mesh.normals.Distinct().ToArray();
        Vector3[] meshFiltered;

        for (int i = 0; i < meshUnfiltered.Length; i++)
        {
            
        }

        return meshFiltered;*/

        return mesh.normals.Distinct().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
