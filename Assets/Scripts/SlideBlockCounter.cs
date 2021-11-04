using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlideBlockCounter : MonoBehaviour
{
    public int zone;

    public TextMeshProUGUI zone1Text;
    public TextMeshProUGUI zone2Text;
    public TextMeshProUGUI zone3Text;
    void Start()
    {
        InvokeRepeating("UpdateCount", 1, 1);
    }

    void UpdateCount()
    {
        switch (zone)
        {
            case 1:
                zone1Text.text = Zone1.counter.ToString();
                break;
            case 2:
                zone2Text.text = Zone2.counter.ToString();
                break;
            case 3:
                zone3Text.text = Zone3.counter.ToString();
                break;
        }
    }
}
