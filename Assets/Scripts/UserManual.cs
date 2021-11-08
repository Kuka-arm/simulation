using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserManual : MonoBehaviour
{
    public GameObject manualMenu;
    public UserManualEntry[] entries;

    public TextMeshProUGUI title;

    public GameObject horizontal;
    public Image horizontalImg;
    public TextMeshProUGUI horizontalText;

    public GameObject vertical;
    public Image verticalImg;
    public TextMeshProUGUI verticalText;

    int manualPos = 0;

    int ManualPos
    {
        get { return manualPos; }
        set
        {
            manualPos = value;

            LoadEntry(manualPos);
        }
    }

    public void ShowMenu()
    {
        manualMenu.SetActive(true);
        ManualPos = ManualPos;
    }

    public void HideMenu()
    {
        manualMenu.SetActive(false);
    }

    public void NextEntry()
    {
        if (ManualPos + 1 < entries.Length)
        {
            ManualPos++;
        }
        else
        {
            ManualPos = 0;
        }
    }

    public void PreviousEntry()
    {
        if (manualPos > 0)
        {
            ManualPos--;
        }
        else
        {
            ManualPos = entries.Length - 1;
        }
    }

    void LoadEntry(int index)
    {
        title.text = entries[index].title;

        switch (entries[index].orientation)
        {
            case Orientation.vertical:
                horizontal.SetActive(false);
                vertical.SetActive(true);
                verticalImg.sprite = entries[index].image;
                verticalText.text = entries[index].description;
                break;
            case Orientation.horizontal:
                vertical.SetActive(false);
                horizontal.SetActive(true);
                horizontalImg.sprite = entries[index].image;
                horizontalText.text = entries[index].description;
                break;
        }
    }
}
