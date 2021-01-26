using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button[] panels;
    public Image[] panelImages;
    public Sprite emptyPanel;

    public Button panel;
    public Image panelImage;
    public PanelScript panelScript;

    public Button startPipe;
    public Image startPipeImage;

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

    public GameObject gameOver;
    public GameObject gameStart;

    public int currentPipe;
    public int fillRate;

    public Button restart;
    public Button start;
    public Button exit;

    public bool isStartingPipe;

    public int score;
    public Text scoreText;
    public Text timer;

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
        restart.onClick.AddListener(Restart);
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(QuitGame);

        colliderLeft = startPipe.transform.Find("Left").GetComponent<BoxCollider2D>();
        colliderTop = startPipe.transform.Find("Top").GetComponent<BoxCollider2D>();
        colliderRight = startPipe.transform.Find("Right").GetComponent<BoxCollider2D>();
        colliderBottom = startPipe.transform.Find("Bottom").GetComponent<BoxCollider2D>();

        colliderLeft.enabled = true;
        colliderTop.enabled = true;
        colliderRight.enabled = true;
        colliderBottom.enabled = true;
        Type();

        score = 0;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;

        timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 10";
    }

    void Update()
    {

    }

    IEnumerator FillStartPipe()
    {
        fillRate = 0;
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 10";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 9";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 8";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 7";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 6";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 5";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 4";
        //yield return new WaitForSeconds(1);
        //timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 3";
        //yield return new WaitForSeconds(1);
        timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 2";
        yield return new WaitForSeconds(1);
        timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 1";
        yield return new WaitForSeconds(1);
        timer.GetComponent<UnityEngine.UI.Text>().text = "Timer: 0";

        if (startPipeImage.sprite == startArray[0])
        {
            startPipeImage.sprite = startFill[0];
            fillRate = 1;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[0])
            {
                startPipeImage.sprite = startFill[1];
            }
            fillRate = 2;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[1])
            {
                startPipeImage.sprite = startFill[2];
            }
            fillRate = 3;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[2])
            {
                startPipeImage.sprite = startFill[3];
            }
            fillRate = 4;

        }

        else if (startPipeImage.sprite == startArray[1])
        {
            startPipeImage.sprite = startFill[4];
            fillRate = 1;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[4])
            {
                startPipeImage.sprite = startFill[5];
            }
            fillRate = 2;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[5])
            {
                startPipeImage.sprite = startFill[6];
            }
            fillRate = 3;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[6])
            {
                startPipeImage.sprite = startFill[7];
            }
            fillRate = 4;
        }

        else if (startPipeImage.sprite == startArray[2])
        {
            startPipeImage.sprite = startFill[8];
            fillRate = 1;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[8])
            {
                startPipeImage.sprite = startFill[9];
            }
            fillRate = 2;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[9])
            {
                startPipeImage.sprite = startFill[10];
            }
            fillRate = 3;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[10])
            {
                startPipeImage.sprite = startFill[11];
            }
            fillRate = 4;

        }

        else if (startPipeImage.sprite == startArray[3])
        {
            startPipeImage.sprite = startFill[12];
            fillRate = 1;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[12])
            {
                startPipeImage.sprite = startFill[13];
            }
            fillRate = 2;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[13])
            {
                startPipeImage.sprite = startFill[14];
            }
            fillRate = 3;
            yield return new WaitForSeconds(1);

            if (startPipeImage.sprite == startFill[14])
            {
                startPipeImage.sprite = startFill[15];
            }
            fillRate = 4;

        }
    }

    public void Type()
    {
        //Debug.Log("Type method for start");
        if (startPipeImage.sprite == startArray[0])
        {
            //Debug.Log("Horizontal Bottom");
            colliderTop.isTrigger = true;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = false;
        }

        else if (startPipeImage.sprite == startArray[1])
        {
            //Debug.Log("Horizontal Top");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = true;
            colliderRight.isTrigger = false;
        }

        else if (startPipeImage.sprite == startArray[2])
        {
            //Debug.Log("Vertical Left");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = false;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = true;
        }

        else if (startPipeImage.sprite == startArray[3])
        {
            //Debug.Log("Vertical Right");
            colliderTop.isTrigger = false;
            colliderLeft.isTrigger = true;
            colliderBottom.isTrigger = false;
            colliderRight.isTrigger = false;
        }
    }

    public void StartGame()
    {
        startPipe = panels[UnityEngine.Random.Range(1, 5) * 10 + UnityEngine.Random.Range(1, 8)];
        currentPipe = System.Array.IndexOf(panels, startPipe);
        startPipe.interactable = false;
        startPipeImage = startPipe.GetComponent<Image>();
        panelImage = panel.GetComponent<Image>();
        startPipeImage.sprite = startArray[UnityEngine.Random.Range(0, startArray.Length)];
        gameStart.SetActive(false);
        StartCoroutine(FillStartPipe());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void Restart()
    {
        gameOver.SetActive(false);
        int i;
        for (i = 0; i <= 69; i++)
        {
            panelImages[i].sprite = emptyPanel;
            panels[i].interactable = true;
        }
        score = 0;
        scoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;

        startPipe = panels[UnityEngine.Random.Range(1, 5) * 10 + UnityEngine.Random.Range(1, 8)];
        currentPipe = System.Array.IndexOf(panels, startPipe);
        startPipe.interactable = false;
        startPipeImage = startPipe.GetComponent<Image>();
        panelImage = panel.GetComponent<Image>();
        startPipeImage.sprite = startArray[UnityEngine.Random.Range(0, startArray.Length)];

        isStartingPipe = true;
        StartGame();
    }
}