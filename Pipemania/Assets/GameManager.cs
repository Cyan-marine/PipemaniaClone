using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button[] panels;
    public Image[] panelImages;

    public Button panel;
    public Image panelImage;
    public PanelScript panelScript;

    public Button startPipe;
    public Image startPipeImage;
    public bool IsSet;

    public Sprite[] pipeArray;
    public Sprite[] startArray;
    public Sprite[] startFill;

    public Sprite[] fillBL;
    public Sprite[] fillBR;
    public Sprite[] fillH;
    public Sprite[] fillTL;
    public Sprite[] fillTR;
    public Sprite[] fillV;

    private BoxCollider2D colliderLeft;
    private BoxCollider2D colliderTop;
    private BoxCollider2D colliderRight;
    private BoxCollider2D colliderBottom;

    //public GameObject collObj;
    //public Image collObjImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startPipe = panels[Random.Range(0, panelImages.Length)];
        startPipe.interactable = false;
        startPipeImage = startPipe.GetComponent<Image>();
        panelImage = panel.GetComponent<Image>();
        startPipeImage.sprite = startArray[Random.Range(0, startArray.Length)];
        //Debug.Log("Starting with sprite:" + startPipeImage.sprite.name);

        colliderLeft = startPipe.transform.Find("Left").GetComponent<BoxCollider2D>();
        colliderTop = startPipe.transform.Find("Top").GetComponent<BoxCollider2D>();
        colliderRight = startPipe.transform.Find("Right").GetComponent<BoxCollider2D>();
        colliderBottom = startPipe.transform.Find("Bottom").GetComponent<BoxCollider2D>();

        colliderLeft.enabled = true;
        colliderTop.enabled = true;
        colliderRight.enabled = true;
        colliderBottom.enabled = true;
        Type();

        StartCoroutine(FillStartPipe());
    }

    void Update()
    {

    }

    IEnumerator FillStartPipe()
    {
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(2);

        if (startPipeImage.sprite == startArray[0])
        {
            //Debug.Log("Stage 1 for HB");
            startPipeImage.sprite = startFill[0];
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[0])
            {
                //Debug.Log("Stage 2 for HB");
                startPipeImage.sprite = startFill[1];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[1])
            {
                //Debug.Log("Stage 3 for HB");
                startPipeImage.sprite = startFill[2];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[2])
            {
                //Debug.Log("Stage 4 for HB");
                startPipeImage.sprite = startFill[3];
            }

            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }

        else if (startPipeImage.sprite == startArray[1])
        {
            //Debug.Log("Stage 1 for HT");
            startPipeImage.sprite = startFill[4];
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[4])
            {
                //Debug.Log("Stage 2 for HT");
                startPipeImage.sprite = startFill[5];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[5])
            {
                //Debug.Log("Stage 3 for HT");
                startPipeImage.sprite = startFill[6];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[6])
            {
                //Debug.Log("Stage 4 for HT");
                startPipeImage.sprite = startFill[7];
            }

            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }

        else if (startPipeImage.sprite == startArray[2])
        {
            //Debug.Log("Stage 1 for VL");
            startPipeImage.sprite = startFill[8];
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[8])
            {
                //Debug.Log("Stage 2 for VL");
                startPipeImage.sprite = startFill[9];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[9])
            {
                //Debug.Log("Stage 3 for VL");
                startPipeImage.sprite = startFill[10];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[10])
            {
                //Debug.Log("Stage 4 for VL");
                startPipeImage.sprite = startFill[11];
            }

            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }

        else
        {
            //Debug.Log("Stage 1 for VR");
            startPipeImage.sprite = startFill[12];
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[12])
            {
                //Debug.Log("Stage 2 for VR");
                startPipeImage.sprite = startFill[13];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[13])
            {
                //Debug.Log("Stage 3 for VR");
                startPipeImage.sprite = startFill[14];
            }
            yield return new WaitForSeconds(2);

            if (startPipeImage.sprite == startFill[14])
            {
                //Debug.Log("Stage 4 for VR");
                startPipeImage.sprite = startFill[15];
            }

            //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }
    }

    //public void FillPipe()
    //{
    //    Debug.Log("Fill Pipe method on");
    //    if (panelImage.sprite == pipeArray[0])
    //    {
    //        Debug.Log("Next pipe should fill now");
    //        panelImage.sprite = fillBL[0];
    //    }

    //    else if (panelImage.sprite == pipeArray[1])
    //    {
    //        Debug.Log("Next pipe should fill now");
    //        panelImage.sprite = fillBR[0];
    //    }

    //    else if (panelImage.sprite == pipeArray[2])
    //    {
    //        Debug.Log("Next pipe should fill now");
    //        panelImage.sprite = fillV[0];
    //    }

    //    else if (panelImage.sprite == pipeArray[3])
    //    {
    //        Debug.Log("Next pipe should fill now");
    //        panelImage.sprite = fillH[0];
    //    }

    //    else if (panelImage.sprite == pipeArray[4])
    //    {
    //        Debug.Log("Next pipe should fill now");
    //        panelImage.sprite = fillTL[0];
    //    }

    //    else if (panelImage.sprite == pipeArray[5])
    //    {
    //        Debug.Log("Next pipe should fill now");
    //        panelImage.sprite = fillTR[0];
    //    }
    //}

    public void Type()
    {
        Debug.Log("Type method for start");
        if (startPipeImage.sprite == startArray[0])
        {
            Debug.Log("Horizontal Bottom");
            colliderTop.isTrigger = true;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = false;
        }

        else if (startPipeImage.sprite == startArray[1])
        {
            Debug.Log("Horizontal Top");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = true;
            colliderRight.isTrigger = false;
        }

        else if (startPipeImage.sprite == startArray[2])
        {
            Debug.Log("Vertical Left");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = true;
        }

        else if (startPipeImage.sprite == startArray[3])
        {
            Debug.Log("Vertical Right");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = true;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = false;
        }
    }
}