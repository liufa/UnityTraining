using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    bool hasMoved = false;

    public void Up()
    {
        Debug.Log("UP");
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Debug.Log(string.Format("{0},{1},{2}", move.x, move.y, move.z));
        transform.position += (move + new Vector3(0, 1, 0));

    }

    public void Down()
    {
        if (!hasMoved)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += (move + new Vector3(0, -1, 0));
            hasMoved = true;
        }
    }

    public void Left()
    {
        if (!hasMoved)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += (move + new Vector3(-1, 0, 0));
            hasMoved = true;
        }
    }

    public void Right()
    {
        if (!hasMoved)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += (move + new Vector3(1, 0, 0));
            hasMoved = true;
        }
    }
}

