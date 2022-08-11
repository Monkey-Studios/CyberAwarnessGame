using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    public Text scoreTotal;
    // Start is called before the first frame update
    void Start()
    {
        scoreTotal.text = GameLogicManager.scoreTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
