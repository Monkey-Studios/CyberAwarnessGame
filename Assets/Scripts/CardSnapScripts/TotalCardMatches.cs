using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCardMatches : MonoBehaviour
{
    public Text scoreTotal;
    // Start is called before the first frame update
    void Start()
    {
        scoreTotal.text = SceneController.cardScore.ToString();
    }

}
