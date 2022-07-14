using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DiceSideCalc : MonoBehaviour
{
    public Vector3[] diceNormals;
    private MeshFilter filter;

    // Start is called before the first frame update
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        diceNormals = CalculateNormals(filter.mesh);
    }

    private Vector3[] CalculateNormals(Mesh mesh)
    {
        return mesh.normals.Distinct().ToArray();

        //How to fix up smaller details

        //Sort list of normals
        //Take first value
        //add to average
        //Take next value
        //Calc the dot product between average and next value
        //If next value is < threshold
        //add to average
        //repeat from step 4
        //else start new value and clear average to value
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach(var valueVector in diceNormals)
        {
            var worldSpaceValueVector = this.transform.localToWorldMatrix.MultiplyVector(valueVector);
            Gizmos.DrawLine(this.transform.position, this.transform.position + worldSpaceValueVector);
        }
    }
}
