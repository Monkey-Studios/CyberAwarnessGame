using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleResult : MonoBehaviour
{
    public int bossHP;
    public int playerHP;
    public bool bossWins;
    public bool playerWins;
    public Animator bossAnimations, playerAnimations;
    public GameObject player, boss;
    public int ammo = 1;
    public Text battleResult;
    public string bossWin = "You have been defeated all hope is lost!";
    public string playerWin = "You are victorious your computer system is safe once again!";
    // Start is called before the first frame update
    void Start()
    {
        bossHP = BossQuizGameLogic.bossCurrentHP;
        playerHP = BossQuizGameLogic.currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHP < playerHP)
        {
            playerWins = true;
            battleResult.text = playerWin;
        }
        else
        {
            bossWins = true;
            battleResult.text = bossWin;
        }
        if (playerWins)
        {
            playerAnimations.SetBool("PlayerShoot", true);
            if (ammo > 0)
            {
                player.GetComponent<FireBullet>().Shoot();
                ammo -= 1;
            }
            bossAnimations.SetBool("BossDeath", true);
        }
        else
        {
            bossAnimations.SetBool("BossShoot", true);
            if (ammo > 0)
            {
                boss.GetComponent<FireBullet>().Shoot();
                ammo -= 1;
            }
            playerAnimations.SetBool("PlayerDeath", true);
        }
    }
}
