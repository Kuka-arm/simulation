using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public GameObject blockMenu;

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        blockMenu.SetActive(true);
    }

    public void Hide()
    {
        blockMenu.SetActive(false);
    }
}
