using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Hero : MonoBehaviour {

    public Animator animator;
    // Use this for initialization
    public void Down()
    {
        var move = GameObject.Find("Hero").transform.position;
        animator.SetTrigger("moveDown");

        transform.position = Vector3.Lerp(move, move + new Vector3(0, -1, 0), 1); 

        
    }
}
