using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public float width = 5f;
    public float height = 5f;
    public float cubeSize = 5;
    public Color color = Color.white;

    void OnDrawGizmos() {
       // Debug.Log("OnGismo");
       //// var pos = Camera.current.transform.position;
       //// Debug.Log("x = "+pos.x +" y = "+pos.y);
       // Gizmos.color = color;
       // for (var y = 0; y <=cubeSize; y++)
       //     {
       //     var start = new Vector3(0, y * width, 0);
       //     var end = new Vector3(height * cubeSize, y * width, 0);
       //    // Debug.Log(" DrawLine x = " + start.x + " y = " + start.y + " x = " + end.x + " y = " + end.y);
       //     Gizmos.DrawLine(start,end);

       // }
       // for (var x = 0; x <= cubeSize; x++)
       // {
       //     Gizmos.DrawLine(new Vector3(x * height,0, 0), new Vector3( x * height, cubeSize * width, 0));

       // }
    }
}
