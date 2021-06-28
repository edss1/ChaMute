using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainUI_Status : MonoBehaviour
{
    Ui_Status status;
    [SerializeField]
    GameObject statusObj;

    [SerializeField]
    Button statusPanelPopupButton;
    [SerializeField]
    Button statusPanelExitButton;
    [SerializeField]
    Image statusImage;

    // Start is called before the first frame update
    void Start()
    {
        statusImage.gameObject.SetActive(false);
        status = statusObj.GetComponent<Ui_Status>();
    }

    // Update is called once per frame
    void Update()
    {
        statusPanelPopupButton.onClick.AddListener(PopupButton);
        statusPanelExitButton.onClick.AddListener(ExitButton);
    }

    //일시정지 활성화
    void PopupButton()
    {
        statusImage.gameObject.SetActive(true);
        statusPanelPopupButton.onClick.RemoveAllListeners();
    }

    void ExitButton()
    {

        status.strPointText.text = status.strPoint.ToString();
        status.strTemp = status.strPoint;

        statusImage.gameObject.SetActive(false);
        statusPanelExitButton.onClick.RemoveAllListeners();
        

    }
}
