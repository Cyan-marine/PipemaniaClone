using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelScript : MonoBehaviour, IPointerClickHandler
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

    public string flowDirection;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    void Start()
    {
        panel.onClick.AddListener(ButtonClicked);
        panelOneImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelTwoImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelThreeImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        panelFourImage.sprite = pipeArray[Random.Range(0, pipeArray.Length)];
        GameManager.instance.isStartingPipe = true;
        GameManager.instance.score = 0;
        audioSource = GetComponent<AudioSource>();
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
                    if (GameManager.instance.currentPipe % 10 != 0)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                        {
                            StartCoroutine(FillPipe("R"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillBL[7])
                {
                    if (GameManager.instance.currentPipe < 60)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                        {
                            StartCoroutine(FillPipe("T"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillBR[3])
                {
                    if (GameManager.instance.currentPipe % 10 != 9)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                        {
                            StartCoroutine(FillPipe("L"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillBR[7])
                {
                    if (GameManager.instance.currentPipe < 60)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                        {
                            StartCoroutine(FillPipe("T"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillV[3])
                {
                    if (GameManager.instance.currentPipe > 9)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                        {
                            StartCoroutine(FillPipe("B"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillV[7])
                {
                    if (GameManager.instance.currentPipe < 60)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe + 10;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[2] || currentSprite == GameManager.instance.pipeArray[4] || currentSprite == GameManager.instance.pipeArray[5])
                        {
                            StartCoroutine(FillPipe("T"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillH[3])
                {
                    if (GameManager.instance.currentPipe % 10 != 9)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                        {
                            StartCoroutine(FillPipe("L"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillH[7])
                {
                    if (GameManager.instance.currentPipe % 10 != 0)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                        {
                            StartCoroutine(FillPipe("R"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTL[7])
                {
                    if (GameManager.instance.currentPipe % 10 != 0)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe - 1;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[5])
                        {
                            StartCoroutine(FillPipe("R"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTL[3])
                {
                    if (GameManager.instance.currentPipe > 9)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                        {
                            StartCoroutine(FillPipe("B"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTR[7])
                {
                    if (GameManager.instance.currentPipe % 10 != 9)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe + 1;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[3] || currentSprite == GameManager.instance.pipeArray[4])
                        {
                            StartCoroutine(FillPipe("L"));
                        }
                    }

                    else
                    {
                        Debug.Log("GameOver");
                        GameManager.instance.gameOver.SetActive(true);
                    }
                }

                else if (currentSprite == GameManager.instance.fillTR[3])
                {
                    if (GameManager.instance.currentPipe > 9)
                    {
                        GameManager.instance.currentPipe = GameManager.instance.currentPipe - 10;
                        currentSprite = GameManager.instance.panels[GameManager.instance.currentPipe].GetComponent<Image>().sprite;
                        if (currentSprite == GameManager.instance.pipeArray[0] || currentSprite == GameManager.instance.pipeArray[1] || currentSprite == GameManager.instance.pipeArray[2])
                        {
                            StartCoroutine(FillPipe("B"));
                        }
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
        audioSource.PlayOneShot(clip, volume);

        if (IsSet == false)
        {
            IsSet = true;
            panel.interactable = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (panelImage.sprite == GameManager.instance.pipeArray[0] ||
                panelImage.sprite == GameManager.instance.pipeArray[1] ||
                panelImage.sprite == GameManager.instance.pipeArray[2] ||
                panelImage.sprite == GameManager.instance.pipeArray[3] ||
                panelImage.sprite == GameManager.instance.pipeArray[4] ||
                panelImage.sprite == GameManager.instance.pipeArray[5])
            {
                panelImage.sprite = emptyPanel;
                panel.interactable = true;
                IsSet = false;
                GameManager.instance.score = GameManager.instance.score - 20;
                GameManager.instance.scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + GameManager.instance.score;
            }

            else
            {
                panel.interactable = false;
            }
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
