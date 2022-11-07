using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class UpgradeButtonDefault : MonoBehaviour
{
    public bool green;
    public bool red;
    public bool blue;
    public bool yellow;
    public bool orange;

    public GameObject upgradeText;
    public GameObject[] zombies;

    public GameObject levelUp_Panel;
    public GameObject orbiter;
    public GameObject helper;

    public void OnPointerEnter()
    {
        //do your stuff when highlighted
        if (green == true) {
            upgradeText.GetComponent<Text>().text = "BULLET DAMAGE INCREASES";
        }
        if (red == true) {
            upgradeText.GetComponent<Text>().text = "BULLET SPEED INCREASES";
        }
        if (blue == true) {
            upgradeText.GetComponent<Text>().text = "ENEMIES EXPLODE INTO BULLETS";
        }       
        if (yellow == true) {
            upgradeText.GetComponent<Text>().text = "ADDS ORBTING PROJECTILE";
        }  
        if (orange == true) {
            upgradeText.GetComponent<Text>().text = "ADDS HELPER";
        }                                
    }

    public void ClickedGreen ()
    {
        if (green == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().dmgBullet += 1;
            zombies = GameObject.FindGameObjectsWithTag("ZombieA");
            foreach (GameObject zombie in zombies) {
                zombie.GetComponent<FlashModeZombie>().dmgBullet += 1;
            }
        }
        Time.timeScale = 1;
        levelUp_Panel.SetActive(false);
    }

    public void ClickedRed ()
    {    
        if (red == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().fireRate -= 50;
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().shootingPower += 1;
            upgradeText.GetComponent<Text>().text = "BULLET SPEED INCREASES";            
        }
        Time.timeScale = 1;
        levelUp_Panel.SetActive(false);
    }

    public void ClickedBlue ()
    {    
        if (blue == true) {
            GameObject.Find("ScoreManagerMode").GetComponent<ScoreManagerMode>().exploderOn = true;
            upgradeText.GetComponent<Text>().text = "ENEMIES EXPLODE INTO BULLETS"; 
        }  
        Time.timeScale = 1;
        levelUp_Panel.SetActive(false);
    }

    public void ClickedYellow ()
    {
        if (yellow == true) {
            Instantiate(orbiter, GameObject.Find("PlayerPrefab").transform.position, Quaternion.identity);
            upgradeText.GetComponent<Text>().text = "ENEMIES EXPLODE INTO BULLETS";
        }     
        Time.timeScale = 1;   
        levelUp_Panel.SetActive(false);
    }

    public void ClickedOrange ()
    {
        if (orange == true) {
            Instantiate(helper, GameObject.Find("PlayerPrefab").transform.position, Quaternion.identity);
            upgradeText.GetComponent<Text>().text = "ADDS HELPER";
        }    
        Time.timeScale = 1;        
        levelUp_Panel.SetActive(false);
    }    
}