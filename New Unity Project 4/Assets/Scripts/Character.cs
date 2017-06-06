using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

  //  bool hasMoved = false;
    public Animator animator;
    public Sprite WalkDown;
    public Sprite WalkLeft;
    public Sprite WalkRight;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        //if (!hasMoved)
        //{
        //    var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //    transform.position += (move + new Vector3(1, 0, 0));
        //    hasMoved = true;
        //}
    }

    public void Up()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //this.GetComponent<Animation>().Play("WalkingUp");
        animator.SetTrigger("moveDown");
        transform.position += (move + new Vector3(0, 1, 0));
    }

    public void Down()
    {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += (move + new Vector3(0, -1, 0));
    }

    public void Left()
    {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += (move + new Vector3(-1, 0, 0));
    }

    public void Right()
    {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += (move + new Vector3(1, 0, 0));
    }
}
