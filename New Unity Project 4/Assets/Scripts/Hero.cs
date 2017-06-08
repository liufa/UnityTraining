using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public Animator animator;
    private Vector3 moveDestination;
    private float moveTime = 0.0f;
    public GameObject buttonPrefab;
    private int buttonCount = 0;
    public int buttonWidth = 30;
    // private string setNeutralTriggerTo = "idle";
    // Use this for initialization
    private List<HeroAction> HeroActions;
    public void Move(HeroAction direction, Vector3 whereToGo, string arrow) {
        if (moveTime <= 0.0f)
        {
            animator.SetTrigger("move"+ Enum.GetName(direction.GetType(), direction));
            moveDestination = transform.position + whereToGo;
            moveTime = 1.0f;

          //  setNeutralTriggerTo =  direction.ToLower()+"Idle";
        }

        MakeButton(arrow);
    }
    public void Down()
    {
        Move(HeroAction.Down, new Vector3(0, -1f, 0), "⇩"); 
    }

    public void Up()
    {
        Move(HeroAction.Up, new Vector3(0, 1f, 0), "⇧");
    }

    public void Left()
    {
        Move(HeroAction.Left, new Vector3(-1f, 0, 0), "⇦");
        
    }

    public void Right()
    {
        Move(HeroAction.Right, new Vector3(1f,0, 0), "⇨");
        
    }

    private void Start()
    {
        moveDestination = transform.position;
    }

    public void MakeButton(string direction)
    {
        
        GameObject button = (GameObject)Instantiate(buttonPrefab);

        var panel = GameObject.Find("CommandPanel");
        button.transform.position = panel.transform.position;
        button.GetComponentsInChildren<Text>()[0].text = direction;
        button.GetComponent<RectTransform>().SetParent(panel.transform);
        button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, (buttonCount)* buttonWidth, buttonWidth);
        button.layer = 5;
        buttonCount++;
    }

    public void Update()
    {
        if (moveTime > 0.0f)
        {
            moveTime -= Time.deltaTime;
            transform.position = Vector3.Lerp(moveDestination, transform.position, moveTime);

            //if (moveTime <= 0.0f)
            //{
            //    return;
            //    //    animator.SetTrigger(setNeutralTriggerTo);
            //}
        }
    }

    
}

public enum HeroAction
{
    Up = 1,
    Right = 2,
    Down = 3,
    Left = 4
}