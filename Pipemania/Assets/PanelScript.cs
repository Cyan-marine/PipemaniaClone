using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public Button panel;
    public bool IsSet;

    public Image panelImage;
    public Image panelOneImage;
    public Image panelTwoImage;
    public Image panelThreeImage;
    public Image panelFourImage;

    public Sprite[] pipeArray;
    public Sprite emptyPanel;

    public BoxCollider2D colliderLeft;
    public BoxCollider2D colliderTop;
    public BoxCollider2D colliderRight;
    public BoxCollider2D colliderBottom;

    public bool ConnectionsTop;
    public bool ConnectionsLeft;
    public bool ConnectionsBottom;
    public bool ConnectionsRight;

    // Start is called before the first frame update
    void Start()
    {
        panel.onClick.AddListener(ButtonClicked);
        panelOneImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelTwoImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelThreeImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelFourImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("Pressed right click, casting ray.");
        //    CastRay();
        //}
    }

    public void ButtonClicked()
    {
        Debug.Log("You have clicked the button!");

        panel.GetComponent<Image>().sprite = panelFourImage.sprite;
        panelFourImage.sprite = panelThreeImage.sprite;
        panelThreeImage.sprite = panelTwoImage.sprite;
        panelTwoImage.sprite = panelOneImage.sprite;
        panelOneImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];

        if (IsSet == false)
        {
            IsSet = true;
            panel.interactable = false;
        }

        Type();

        colliderLeft = panel.transform.Find("Left").GetComponent<BoxCollider2D>();
        colliderLeft.isTrigger = true;
        if (colliderLeft.isTrigger == true)
        {
            Debug.Log("collider Left is a trigger");
        }

        colliderTop = panel.transform.Find("Top").GetComponent<BoxCollider2D>();
        colliderTop.isTrigger = true;
        if (colliderTop.isTrigger == true)
        {
            Debug.Log("collider Top is a trigger");
        }

        colliderRight = panel.transform.Find("Right").GetComponent<BoxCollider2D>();
        colliderRight.isTrigger = true;
        if (colliderRight.isTrigger == true)
        {
            Debug.Log("collider Right is trigger");
        }

        colliderBottom = panel.transform.Find("Bottom").GetComponent<BoxCollider2D>();
        colliderBottom.isTrigger = true;
        if (colliderBottom.isTrigger == true)
        {
            Debug.Log("collider Bottom is trigger");
        }

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay method");
        //Debug.Log("Name: " + gameObject.name);
        //Debug.Log("Second name: " + collision.gameObject.name);

    }

    public void Type()
    {
        //Debug.Log("Type method");
        if (panelImage.sprite == pipeArray[0])
        {
            ConnectionsTop = false;
            ConnectionsLeft = true;
            ConnectionsBottom = true;
            ConnectionsRight = false;

            if (ConnectionsTop == true)
            {
                //Debug.Log("ConnectionsTop is true");
            }
            else if (ConnectionsTop == false)
            {
                //Debug.Log("ConnectionsTop is false");
            }
        }

        if (panelImage.sprite == pipeArray[1])
        {
            //Debug.Log("Bottom Right");
            ConnectionsTop = false;
            ConnectionsLeft = false;
            ConnectionsBottom = true;
            ConnectionsRight = true;
        }

        if (panelImage.sprite == pipeArray[2])
        {
            //Debug.Log("Cross");
            ConnectionsTop = true;
            ConnectionsLeft = true;
            ConnectionsBottom = true;
            ConnectionsRight = true;
        }

        if (panelImage.sprite == pipeArray[3])
        {
            //Debug.Log("Horizontal");
            ConnectionsTop = false;
            ConnectionsLeft = true;
            ConnectionsBottom = false;
            ConnectionsRight = true;
        }

        if (panelImage.sprite == pipeArray[4])
        {
            //Debug.Log("Top Left");
            ConnectionsTop = true;
            ConnectionsLeft = true;
            ConnectionsBottom = false;
            ConnectionsRight = false;
        }

        if (panelImage.sprite == pipeArray[5])
        {
            //Debug.Log("Top Right");
            ConnectionsTop = true;
            ConnectionsLeft = false;
            ConnectionsBottom = false;
            ConnectionsRight = true;
        }

        if (panelImage.sprite == pipeArray[6])
        {
            //Debug.Log("Vertical");
            ConnectionsTop = true;
            ConnectionsLeft = false;
            ConnectionsBottom = true;
            ConnectionsRight = false;
        }
    }

    //void CastRay()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
    //    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, -Vector2.up);
    //    if (hit.collider != null)
    //    {
    //        Debug.Log("Hit object: "); //+ hit.collider.gameobject.name);
    //        Debug.Log(hit.collider.gameObject.name);
    //        IsSet = false;
    //        panel.interactable = true;
    //        panelImage.sprite = emptyPanel;
    //    }
    //}

}
