using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int selectedResult;
    public int selectedVector;
    public Vector3[] vectorPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float bestDot = -1; //Default value is negative

        for(int i = 0; i < vectorPoints.Length; ++i)
        {
            var valueVector = vectorPoints[i];
            var worldSpaceValueVector = this.transform.localToWorldMatrix.MultiplyVector(valueVector);
            float dot = Vector3.Dot(worldSpaceValueVector, Vector3.up);

            if (dot != bestDot)
            {
                bestDot = dot;
                selectedVector = i;
            }
        }

        selectedResult = selectedVector;
    }

    //Draws out the vectors
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach(var valueVector in vectorPoints)
        {
            var worldSpaceValueVector = this.transform.localToWorldMatrix.MultiplyVector(valueVector);
            Gizmos.DrawLine(this.transform.position, this.transform.position + worldSpaceValueVector);
        }
    }
}
