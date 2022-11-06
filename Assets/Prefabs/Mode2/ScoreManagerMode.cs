using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerMode : MonoBehaviour
{
    public int zombieDeaths;
    public int soldierDeaths;

    public int xp = 0;
    public int barXP = 0;
    public float xpNextLevel = 10;
    public float lastXP = 0;

    public float ammo;

    public GameObject xpCount;
    public GameObject levelCount;
    public GameObject levelNumber;
    public GameObject ammoCount;

    public GameObject[] zombieCount;
    public GameObject[] soldierCount;

    public int currentXPLevel;
    public GameObject levelBar;

    public GameObject particles;
    public GameObject levelUpSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SceneManager.LoadScene("Zombies");
        }        

        levelNumber.GetComponent<Text>().text = currentXPLevel.ToString();
        xpCount.GetComponent<Text>().text = xp.ToString();
        levelCount.GetComponent<Text>().text = xpNextLevel.ToString();
        if (xp >= xpNextLevel) {
            currentXPLevel = currentXPLevel + 1;
            barXP = 0;
            lastXP = xpNextLevel;
            xpNextLevel = Mathf.Round((xpNextLevel + xpNextLevel) * 1.05f);
            GameObject.Find("PlayerPrefab").GetComponent<DamageMode>().maxHealth += currentXPLevel*10;
            GameObject.Find("PlayerPrefab").GetComponent<DamageMode>().health = GameObject.Find("PlayerPrefab").GetComponent<DamageMode>().maxHealth;   
            GameObject.Find("PlayerPrefab").GetComponentInChildren<PlayerGun>().magMax += 1;         
            StartCoroutine(SlowMotionRoutine());
        }
        levelBar.GetComponent<HealthBarHandler>().SetHealthBarValue(barXP/(xpNextLevel-lastXP));

        ammoCount.GetComponent<Text>().text = (GameObject.Find("PlayerPrefab").GetComponentInChildren<PlayerGun>().magSize - GameObject.Find("PlayerPrefab").GetComponentInChildren<PlayerGun>().magCurrent).ToString();
    }

    IEnumerator SlowMotionRoutine() {
        GetComponent<SlowMotion>().enabled = true;
        Instantiate(particles, GameObject.Find("PlayerPrefab").transform.position, Quaternion.identity);
        Instantiate(levelUpSFX, GameObject.Find("PlayerPrefab").transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        GetComponent<SlowMotion>().enabled = false;
    }     
}
