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
        status.dexPointText.text = status.dexPoint.ToString();
        status.dexTemp = status.dexPoint;
        status.agiPointText.text = status.agiPoint.ToString();
        status.agiTemp = status.agiPoint;
        status.vitPointText.text = status.vitPoint.ToString();
        status.vitTemp = status.vitPoint;
        status.intPointText.text = status.intPoint.ToString();
        status.intTemp = status.intPoint;
        status.engPointText.text = status.engPoint.ToString();
        status.engTemp = status.engPoint;
        status.lukPointText.text = status.lukPoint.ToString();
        status.lukTemp = status.lukPoint;

        status.statusPointText.text = status.statusPoint.ToString();
        status.statusPointTemp = status.statusPoint;









        statusImage.gameObject.SetActive(false);
        statusPanelExitButton.onClick.RemoveAllListeners();
        

    }
}
