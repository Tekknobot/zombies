using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int zombieDeaths;
    public int soldierDeaths;
    public int civilianDeaths;

    public int xp = 0;
    public int barXP = 0;
    public float xpNextLevel = 10;
    public float lastXP = 0;

    public GameObject zombieDeathCount;
    public GameObject soldierDeathCount;
    public GameObject civilianDeathCount;
    public GameObject xpCount;
    public GameObject levelCount;
    public GameObject levelNumber;
    public GameObject zombieCap;

    public GameObject[] zombieCount;
    public GameObject[] soldierCount;

    public int currentXPLevel;
    public GameObject levelBar;

    public int zombieLimit = 10;
    public float zombieMaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombieCount = GameObject.FindGameObjectsWithTag("zombie");
        soldierCount = GameObject.FindGameObjectsWithTag("soldier");
        zombieDeathCount.GetComponent<Text>().text = zombieCount.Length.ToString();
        
        foreach (GameObject zombie in zombieCount) {
            levelNumber.GetComponent<Text>().text = zombieCount[0].GetComponent<FollowPlayer>().currentXPLevel.ToString();
            zombieCap.GetComponent<Text>().text = zombieCount[0].GetComponent<FollowPlayer>().zombieLimit.ToString();
        }

        xpCount.GetComponent<Text>().text = xp.ToString();
        //soldierDeathCount.GetComponent<Text>().text = soldierDeaths.ToString();
        //civilianDeathCount.GetComponent<Text>().text = civilianDeaths.ToString();
        levelCount.GetComponent<Text>().text = xpNextLevel.ToString();
        levelBar.GetComponent<HealthBarHandler>().SetHealthBarValue(barXP/(xpNextLevel-lastXP));
    }
}
