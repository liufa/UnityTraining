using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public Animator animator;
    // Use this for initialization
    public void Down()
    {

        MakeButton("Down");

        var move = GameObject.Find("Hero").transform.position;
        animator.SetTrigger("moveDown");

        transform.position = Vector3.Lerp(move, move + new Vector3(0, -1f, 0), 1f); 

        
    }

    public void MakeButton(string direction)
    {
        
        GameObject button = new GameObject();
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.transform.position = new Vector3(-0,0,0);
        button.GetComponent<RectTransform>().SetParent(GameObject.Find("CommandPanel").transform);
        button.SetActive(true);
        
        // button.active = false;
        // (button.GetComponentInChildren(typeof(Text), true) as Text).text = direction;
    }
}
