using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public Button panel;
    private bool IsSet;

    public Image panelImage;
    public Image panelOneImage;
    public Image panelTwoImage;
    public Image panelThreeImage;
    public Image panelFourImage;
    public Image currentImage;

    public Sprite[] pipeArray;
    public Sprite emptyPanel;
    public Sprite currentSprite;

    private BoxCollider2D colliderLeft;
    private BoxCollider2D colliderTop;
    private BoxCollider2D colliderRight;
    private BoxCollider2D colliderBottom;

    public bool conBool;
    public Image collImage;

    //public bool GameManager.instance.isStartingPipe;

    public string flowDirection;

    void Start()
    {
        panel.onClick.AddListener(ButtonClicked);
        panelOneImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelTwoImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelThreeImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelFourImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        EnableColliders();
        GameManager.instance.isStartingPipe = true;
        GameManager.instance.score = 0;
    }

    void Update()
    {
        //Debug.Log(GameManager.instance.currentPipe);
        //Debug.Log(GameManager.instance.fillRate);
        if (GameManager.instance.fillRate == 4)
        {
            GameManager.instance.fillRate = 0;
            if (GameManager.instance.isStartingPipe == true)
            {
                currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                Debug.Log(currentSprite);

                if (currentSprite == GameManager.instance.startFill[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                    {
                        StartCoroutine(FillPipe("B"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.startFill[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("T"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.startFill[11])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                    {
                        StartCoroutine(FillPipe("L"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.startFill[15])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("R"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                GameManager.instance.isStartingPipe = false;
            }

            else
            {
                currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                Debug.Log(currentSprite);

                if (currentSprite == GameManager.instance.fillBL[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("R"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillBL[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("T"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillBR[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                    {
                        StartCoroutine(FillPipe("L"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillBR[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("T"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillV[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                    {
                        StartCoroutine(FillPipe("B"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillV[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("T"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillH[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                    {
                        StartCoroutine(FillPipe("L"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillH[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("R"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTL[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                    {
                        StartCoroutine(FillPipe("R"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTL[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                    {
                        StartCoroutine(FillPipe("B"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTR[7])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                    {
                        StartCoroutine(FillPipe("L"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTR[3])
                {
                    GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                    currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                    if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                    {
                        StartCoroutine(FillPipe("B"));
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }
            }
        }
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

        else
        {
            DisableColliders();
        }
    }

    IEnumerator FillPipe(string flowDirection)
    {
        //Debug.Log("FILL PIPE");
        currentImage = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>();
        yield return new WaitForSeconds(1);
        if (currentSprite == GameManager.instance.pipeArray[0])
        {
            if (flowDirection == "B")
            {
                currentImage.sprite = GameManager.instance.fillBL[0];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBL[1];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBL[2];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBL[3];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                currentImage.sprite = GameManager.instance.fillBL[4];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBL[5];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBL[6];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBL[7];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }
        }

        else if (currentSprite == GameManager.instance.pipeArray[1])
        {
            if (flowDirection == "B")
            {
                currentImage.sprite = GameManager.instance.fillBR[0];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBR[1];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBR[2];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBR[3];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                currentImage.sprite = GameManager.instance.fillBR[4];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBR[5];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBR[6];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillBR[7];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }
        }

        else if (currentSprite == GameManager.instance.pipeArray[2])
        {
            if (flowDirection == "B")
            {
                currentImage.sprite = GameManager.instance.fillV[0];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillV[1];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillV[2];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillV[3];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                currentImage.sprite = GameManager.instance.fillV[4];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillV[5];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillV[6];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillV[7];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }
        }

        else if (currentSprite == GameManager.instance.pipeArray[3])
        {
            if (flowDirection == "L")
            {
                currentImage.sprite = GameManager.instance.fillH[0];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillH[1];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillH[2];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillH[3];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                currentImage.sprite = GameManager.instance.fillH[4];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillH[5];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillH[6];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillH[7];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }
        }

        else if (currentSprite == GameManager.instance.pipeArray[4])
        {
            if (flowDirection == "L")
            {
                currentImage.sprite = GameManager.instance.fillTL[0];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTL[1];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTL[2];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTL[3];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                currentImage.sprite = GameManager.instance.fillTL[4];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTL[5];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTL[6];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTL[7];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }
        }

        else if (currentSprite == GameManager.instance.pipeArray[5])
        {
            if (flowDirection == "R")
            {
                currentImage.sprite = GameManager.instance.fillTR[0];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTR[1];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTR[2];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTR[3];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                currentImage.sprite = GameManager.instance.fillTR[4];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTR[5];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTR[6];
                yield return new WaitForSeconds(1);
                currentImage.sprite = GameManager.instance.fillTR[7];
                GameManager.instance.fillRate = 4;
                GameManager.instance.score = GameManager.instance.score + 100;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }
        }
    }
}
