using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // this is required to load a new scene

public class ProtectionBarController : MonoBehaviour
{
    public Slider healthSlider;
    public Slider bossHealthSlider; // reference to slider component on the game object
    public GameObject HUD; // reference so can call functions from scripts attached to canvas

    void Update()
    {

    }
}
