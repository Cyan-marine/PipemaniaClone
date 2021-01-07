using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public bool gameOver;
    public Button panel;
    private bool IsSet;

    public Image panelImage;
    public Image panelOneImage;
    public Image panelTwoImage;
    public Image panelThreeImage;
    public Image panelFourImage;

    public Sprite[] pipeArray;
    public Sprite emptyPanel;

    private BoxCollider2D colliderLeft;
    private BoxCollider2D colliderTop;
    private BoxCollider2D colliderRight;
    private BoxCollider2D colliderBottom;

    public bool conBool;
    public Image collImage;

    void Start()
    {
        panel.onClick.AddListener(ButtonClicked);
        panelOneImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelTwoImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelThreeImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelFourImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        EnableColliders();
    }

    void Update()
    {
        //game over bool
    }

    public void ButtonClicked()
    {
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
    }

    IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("OnTrigger method");
        //Debug.Log("Name: " + gameObject.name);
        //Debug.Log("Second name: " + collision.gameObject.name);

        //GameManager.instance.collObjImage = collision.GetComponent<Image>();

        if (collision.gameObject.name == "Bottom" && collision.isTrigger == true)
        {
            if (colliderTop.isTrigger == true)
            {
                //Debug.Log("There is a Top-Bottom connection");

                if (GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[3] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[7] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[11] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[15])
                {
                    //Debug.Log("PanelScript reads start pipe images");
                    //GameManager.instance.FillPipe();
                    conBool = true;
                }
            }

            else
            {
                //Debug.Log("There is no Top-Bottom connection");
                conBool = false;
            }
        }

        else if (collision.gameObject.name == "Left" && collision.isTrigger == true)
        {
            if (colliderRight.isTrigger == true)
            {
                //Debug.Log("There is a Left-Right connection");

                if (GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[3] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[7] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[11] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[15])
                {
                    //Debug.Log("PanelScript reads start pipe images");
                    //GameManager.instance.FillPipe();
                    conBool = true;
                }
            }

            else
            {
                //Debug.Log("There is no Left-Right connection");
                conBool = false;
            }
        }

        else if (collision.gameObject.name == "Top" && collision.isTrigger == true)
        {
            if (colliderBottom.isTrigger == true)
            {
                //Debug.Log("There is a Top-Bottom connection");

                if (GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[3] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[7] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[11] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[15])
                {
                    //Debug.Log("PanelScript reads start pipe images");
                    //GameManager.instance.FillPipe();
                    conBool = true;
                }
            }

            else
            {
                //Debug.Log("There is no Top-Bottom connection");
                conBool = false;
            }
        }

        else if (collision.gameObject.name == "Right" && collision.isTrigger == true)
        {
            if (colliderLeft.isTrigger == true)
            {
                //Debug.Log("There is a Left-Right connection");

                if (GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[3] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[7] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[11] ||
                    GameManager.instance.startPipeImage.sprite == GameManager.instance.startFill[15])
                {
                    //Debug.Log("PanelScript reads start pipe images");
                    //GameManager.instance.FillPipe();
                    conBool = true;
                }
            }

            else
            {
                //Debug.Log("There is no Left-Right connection");
                conBool = false;
            }
        }

        Debug.Log("coonbool: " + conBool + " gameObject name: " + gameObject.name);

        if (conBool == true && gameObject.name == GameManager.instance.startPipe.name)
        {
            collImage = collision.gameObject.GetComponentInParent<Image>();
            yield return new WaitForSeconds(2);
            if (collImage.sprite == pipeArray[0])
            {
                if (collision.gameObject.name == "Bottom")
                {
                    collImage.sprite = GameManager.instance.fillBL[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[3];
                }

                else if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillBL[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[7];
                }
            }

            else if (collImage.sprite == pipeArray[1])
            {
                if (collision.gameObject.name == "Bottom")
                {
                    collImage.sprite = GameManager.instance.fillBR[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[3];
                }

                if (collision.gameObject.name == "Right")
                {
                    collImage.sprite = GameManager.instance.fillBR[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[7];
                }
            }

            else if (collImage.sprite == pipeArray[2])
            {
                if (collision.gameObject.name == "Bottom")
                {
                    collImage.sprite = GameManager.instance.fillV[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[3];
                }

                if (collision.gameObject.name == "Top")
                {
                    collImage.sprite = GameManager.instance.fillV[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[7];
                }
            }

            else if (collImage.sprite == pipeArray[3])
            {
                if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillH[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[3];
                }

                if (collision.gameObject.name == "Right")
                {
                    collImage.sprite = GameManager.instance.fillH[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[7];
                }
            }

            else if (collImage.sprite == pipeArray[4])
            {
                if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillTL[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[3];
                }

                if (collision.gameObject.name == "Top")
                {
                    collImage.sprite = GameManager.instance.fillTL[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[7];
                }
            }

            else if (collImage.sprite == pipeArray[5])
            {
                if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillTR[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[3];
                }

                if (collision.gameObject.name == "Top")
                {
                    collImage.sprite = GameManager.instance.fillTR[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[7];
                }
            }
        }

        if (conBool == true &&
           (gameObject.GetComponent<Image>().sprite == GameManager.instance.fillBL[3] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillBL[7] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillBR[3] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillBR[7] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillV[3] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillV[7] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillH[3] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillH[7] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillTL[3] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillTL[7] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillTR[3] ||
           gameObject.GetComponent<Image>().sprite == GameManager.instance.fillTR[7]
           ))
        {
            collImage = collision.gameObject.GetComponentInParent<Image>();
            yield return new WaitForSeconds(2);
            if (collImage.sprite == pipeArray[0])
            {
                if (collision.gameObject.name == "Bottom")
                {
                    collImage.sprite = GameManager.instance.fillBL[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[3];
                }

                else if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillBL[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBL[7];
                }
            }

            else if (collImage.sprite == pipeArray[1])
            {
                if (collision.gameObject.name == "Bottom")
                {
                    collImage.sprite = GameManager.instance.fillBR[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[3];
                }

                if (collision.gameObject.name == "Right")
                {
                    collImage.sprite = GameManager.instance.fillBR[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillBR[7];
                }
            }

            else if (collImage.sprite == pipeArray[2])
            {
                if (collision.gameObject.name == "Bottom")
                {
                    collImage.sprite = GameManager.instance.fillV[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[3];
                }

                if (collision.gameObject.name == "Top")
                {
                    collImage.sprite = GameManager.instance.fillV[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillV[7];
                }
            }

            else if (collImage.sprite == pipeArray[3])
            {
                if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillH[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[3];
                }

                if (collision.gameObject.name == "Right")
                {
                    collImage.sprite = GameManager.instance.fillH[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillH[7];
                }
            }

            else if (collImage.sprite == pipeArray[4])
            {
                if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillTL[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[3];
                }

                if (collision.gameObject.name == "Top")
                {
                    collImage.sprite = GameManager.instance.fillTL[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTL[7];
                }
            }

            else if (collImage.sprite == pipeArray[5])
            {
                if (collision.gameObject.name == "Left")
                {
                    collImage.sprite = GameManager.instance.fillTR[0];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[1];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[2];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[3];
                }

                if (collision.gameObject.name == "Top")
                {
                    collImage.sprite = GameManager.instance.fillTR[4];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[5];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[6];
                    yield return new WaitForSeconds(2);
                    collImage.sprite = GameManager.instance.fillTR[7];
                }
            }
        }
    }

    public void EnableColliders()
    {
        colliderLeft = panel.transform.Find("Left").GetComponent<BoxCollider2D>();
        colliderLeft.enabled = true;

        colliderTop = panel.transform.Find("Top").GetComponent<BoxCollider2D>();
        colliderTop.enabled = true;

        colliderRight = panel.transform.Find("Right").GetComponent<BoxCollider2D>();
        colliderRight.enabled = true;

        colliderBottom = panel.transform.Find("Bottom").GetComponent<BoxCollider2D>();
        colliderBottom.enabled = true;

    }

    public void DisableColliders()
    {
        colliderLeft = panel.transform.Find("Left").GetComponent<BoxCollider2D>();
        colliderLeft.enabled = false;

        colliderTop = panel.transform.Find("Top").GetComponent<BoxCollider2D>();
        colliderTop.enabled = false;

        colliderRight = panel.transform.Find("Right").GetComponent<BoxCollider2D>();
        colliderRight.enabled = false;

        colliderBottom = panel.transform.Find("Bottom").GetComponent<BoxCollider2D>();
        colliderBottom.enabled = false;
    }

    public void Type()
    {
        //Debug.Log("Type method");
        if (panelImage.sprite == pipeArray[0])
        {
            EnableColliders();
            //Bottom Left
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = true;
            colliderBottom.isTrigger = true;
            colliderRight.isTrigger = false;
        }

        else if (panelImage.sprite == pipeArray[1])
        {
            EnableColliders();
            //Debug.Log("Bottom Right");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = true;
            colliderRight.isTrigger = true;
        }

        else if (panelImage.sprite == pipeArray[2])
        {
            EnableColliders();
            //Debug.Log("Vertical");
            colliderTop.isTrigger = true;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = true;
            colliderRight.isTrigger = false;
        }

        else if (panelImage.sprite == pipeArray[3])
        {
            EnableColliders();
            //Debug.Log("Horizontal");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = true;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = true;
        }

        else if (panelImage.sprite == pipeArray[4])
        {
            EnableColliders();
            //Debug.Log("Top Left");
            colliderTop.isTrigger = true;
            colliderLeft.isTrigger = true;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = false;
        }

        else if (panelImage.sprite == pipeArray[5])
        {
            EnableColliders();
            //Debug.Log("Top Right");
            colliderTop.isTrigger = true;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = true;
        }

        //else if (panelImage.sprite == pipeArray[6])
        //{
        //    EnableColliders();
        //    //Debug.Log("Cross");
        //    colliderTop.isTrigger = true;
        //    colliderLeft.isTrigger = true;
        //    colliderBottom.isTrigger = true;
        //    colliderRight.isTrigger = true;
        //}

        else
        {
            DisableColliders();
        }
    }

}
