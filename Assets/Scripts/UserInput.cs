using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInput : MonoBehaviour
{
    public GameObject blockMenu;
    public BlockSpawner blockSpawner;
    public TMP_InputField usersBlockInput;

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

    public void spawnBlock()
    {
        blockSpawner.SpawnBlock(int.Parse(usersBlockInput.text));
    }
}
