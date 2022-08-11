using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwatterController : MonoBehaviour
{
    public Text scoreText;
    public static int virusTotal;
    private VirusSpotter ms;
    //When the game starts the players score is 0 and this script calls upon the virus spotter script
    void Start()
    {
        virusTotal = 0;
        ms = GetComponent<VirusSpotter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && ms.gameTime > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Enemy")
                {
                    Destroy(hit.transform.gameObject);
                    virusTotal += 1;
                    scoreText.text = virusTotal.ToString();
                    ms.Spawn();
                }
                else 
                {
                    Destroy(hit.transform.gameObject);
                    ms.gameTime -= 2;
                    ms.SpawnFriendly();
                }

            }
        }
    }
}
