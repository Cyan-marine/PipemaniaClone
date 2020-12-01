using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite pipeCross;
    public Button panel;
    public bool IsSet;

    public Image panelOneImage;
    public Image panelTwoImage;
    public Image panelThreeImage;
    public Image panelFourImage;

    public Sprite[] pipeArray;
    public Sprite emptyPanel;

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
        //broken AF
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log("Right click");
        //    IsSet = false;
        //    panel.interactable = true;
        //    panel.GetComponent<Image>().sprite = emptyPanel;
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
    }

    //broken AF
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Debug.Log("Right click");
    //        panel.interactable = true;
    //        IsSet = false;
    //        panel.GetComponent<Image>().sprite = emptyPanel;
    //    }
    //}

}
