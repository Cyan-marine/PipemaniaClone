using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] panels;
    public Image[] panelImages;
    public Button panel;

    public Button startingPipe;
    public Image startingPipeImage;
    public bool IsSet;

    public GameObject nextPanel;

    public Sprite[] pipeArray;


    // Start is called before the first frame update
    void Start()
    {
        startingPipe = panels[Random.Range(0, panelImages.Length)];
        startingPipe.interactable = false;
        startingPipe.GetComponent<Image>().sprite = pipeArray[Random.Range(0, pipeArray.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Ta dam!");
    //    Debug.Log("Name: " + gameObject.name);
    //}

}
