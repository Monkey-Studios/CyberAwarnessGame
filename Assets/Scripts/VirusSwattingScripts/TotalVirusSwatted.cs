using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalVirusSwatted : MonoBehaviour
{
    public Text scoreTotal;
    // Start is called before the first frame update
    void Start()
    {
        scoreTotal.text = SwatterController.virusTotal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
