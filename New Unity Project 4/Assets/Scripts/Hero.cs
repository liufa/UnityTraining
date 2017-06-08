using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{

    public Animator animator;
    private Vector3 moveDestination;
    private float moveTime = 0.0f;
    public GameObject buttonPrefab;
    private int buttonCount = 0;
    public int buttonWidth = 30;
    private bool isExecuting = false;
    // private string setNeutralTriggerTo = "idle";
    // Use this for initialization
    private List<MovementAction> HeroActions = new List<MovementAction>();
    public void StoreAction(MovementAction movementAction)
    {
        HeroActions.Add(movementAction);
        MakeButton(movementAction.IconString);
    }
    public void Down()
    {
        StoreAction(new MovementAction(HeroAction.Down, new Vector3(0, -1f, 0), "⇩"));
    }

    public void Up()
    {
        StoreAction(new MovementAction(HeroAction.Up, new Vector3(0, 1f, 0), "⇧"));
    }

    public void Left()
    {
        StoreAction(new MovementAction(HeroAction.Left, new Vector3(-1f, 0, 0), "⇦"));

    }

    public void Right()
    {
        StoreAction(new MovementAction(HeroAction.Right, new Vector3(1f, 0, 0), "⇨"));

    }

    public void Execute()
    {
        isExecuting = true;
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
        button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, (buttonCount) * buttonWidth, buttonWidth);
        button.layer = 5;
        buttonCount++;
    }

    public void Update()
    {
        if (moveTime > 0.0f)
        {
            moveTime -= Time.deltaTime;
            transform.position = Vector3.Lerp(moveDestination, transform.position, moveTime);
        }
        if (isExecuting)
        {
            if (HeroActions.Any())
            {
                if (moveTime <= 0.0f)
                {
                    var heroAction = HeroActions.ElementAt(0);
                    animator.SetTrigger("move" + Enum.GetName(heroAction.Action.GetType(), heroAction.Action));
                    moveDestination = transform.position + heroAction.Vector;
                    moveTime = 1f;
                    HeroActions.RemoveAt(0);
                }  
            }
            else
            {
                isExecuting = false;
            }
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

public class MovementAction
{
    public MovementAction(HeroAction action, Vector3 vector, string iconString)
    {
        this.Action = action;
        this.Vector = vector;
        this.IconString = iconString;
    }

    public HeroAction Action { get; private set; }
    public Vector3 Vector { get; private set; }
    public string IconString { get; private set; }
}