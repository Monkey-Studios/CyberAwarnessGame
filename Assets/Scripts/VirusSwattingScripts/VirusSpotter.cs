using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VirusSpotter : MonoBehaviour
{
    public GameObject[] virusPrefab;
    public GameObject[] friendlyPrefab;
    public Transform[] spawnPoints;
    public float gameTime;
    public Text gameText;
    public bool firstSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        //Calls upon the spawn functionality to spawn the "Friendly pop ups"
        SpawnFriendly();
        //Calls upon the spawn functionality to spawn the "Viruses"
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //This allows the games timer to tick downwards a second at a time.
        gameTime -= Time.deltaTime; 
        if(gameTime < 1)
        {
            gameTime = 0;
            SceneManager.LoadScene("WackAVirusEndScreen");
        }
        gameText.text = gameTime.ToString();
    }
    //This functionality will be used to set and spawn the "Viruses" in different points on boot up and when they are hit. 
    public void Spawn()
    {
        int obj = Random.Range(0, virusPrefab.Length);
        GameObject virus = Instantiate(virusPrefab[obj]) as GameObject;
        virus.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        if(firstSpawn == true)
        {
            //Spawns in "Virus 2"
            GameObject virus2 = Instantiate(virusPrefab[Random.Range(0, virusPrefab.Length)]) as GameObject;
            virus2.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            //Spawns in "Virus 3"
            GameObject virus3 = Instantiate(virusPrefab[Random.Range(0, virusPrefab.Length)]) as GameObject;
            virus3.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            //Stops duplicates from respawing after intial start
            firstSpawn = false;
        }
    }
    public void SpawnFriendly()
    {
        int obj = Random.Range(0, friendlyPrefab.Length);
        GameObject friendly = Instantiate(friendlyPrefab[obj]) as GameObject;
        friendly.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        if (firstSpawn == true)
        {
            //Spawns in "friendly2"
            GameObject friendly2 = Instantiate(friendlyPrefab[Random.Range(0, friendlyPrefab.Length)]) as GameObject;
            friendly2.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            //Spawns in "friendly3"
            GameObject friendly3 = Instantiate(friendlyPrefab[Random.Range(0, friendlyPrefab.Length)]) as GameObject;
            friendly3.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            //Stops duplicates from respawing after intial start
        }
    }

}
