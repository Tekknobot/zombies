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
    public float xpNextLevel = 10;

    public GameObject zombieDeathCount;
    public GameObject soldierDeathCount;
    public GameObject civilianDeathCount;
    public GameObject xpCount;
    public GameObject levelCount;

    public GameObject[] zombieCount;

    public int currentXPLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombieCount = GameObject.FindGameObjectsWithTag("zombie");
        zombieDeathCount.GetComponent<Text>().text = zombieCount.Length.ToString();

        xpCount.GetComponent<Text>().text = xp.ToString();
        //soldierDeathCount.GetComponent<Text>().text = soldierDeaths.ToString();
        //civilianDeathCount.GetComponent<Text>().text = civilianDeaths.ToString();
        levelCount.GetComponent<Text>().text = xpNextLevel.ToString();
    }
}
