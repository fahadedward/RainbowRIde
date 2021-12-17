using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    public Slider slider;
    public void setMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    // Start is called before the first frame update

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
