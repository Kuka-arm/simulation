using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfColorSelect : MonoBehaviour
{
    public GameObject mainColor;
    public GameObject colorPanel;
    PositionData posData;

    private void Awake()
    {
        posData = GetComponentInParent<PositionData>();
    }

    public void ViewColorPanel()
    {
        colorPanel.SetActive(true);
        mainColor.SetActive(false);
    }

    public void HideColorPanel()
    {
        colorPanel.SetActive(false);
        mainColor.SetActive(true);
    }

    public void ColorRed()
    {
        HideColorPanel();
        posData.colorObj.GetComponent<Image>().color = Color.red;
        posData.nodeAction.Color = Color.red;
    }
    public void ColorGreen()
    {
        HideColorPanel();
        posData.colorObj.GetComponent<Image>().color = Color.green;
        posData.nodeAction.Color = Color.green;
    }
    public void ColorBlue()
    {
        HideColorPanel();
        posData.colorObj.GetComponent<Image>().color = Color.blue;
        posData.nodeAction.Color = Color.blue;
    }
}
