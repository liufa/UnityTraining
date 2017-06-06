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
    // Use this for initialization
    public void Down()
    {
        if (moveTime <= 0.0f)
        {
            animator.SetTrigger("moveDown");
            moveDestination = transform.position + new Vector3(0, -1f, 0);
            moveTime = 1.0f;

        }

        MakeButton("⇩");        
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

            if (moveTime <= 0.0f)
            {
                animator.SetTrigger("idle");
            }
        }
    }
}
