using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public Animator animator;
    // Use this for initialization
    public void Down()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //this.GetComponent<Animation>().Play("WalkingUp");
        animator.SetTrigger("moveDown");
        transform.position += (move + new Vector3(0, -1, 0));
    }
}
