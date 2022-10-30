using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 1200;
    public float interval = 60;
    public float timeElapsed = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeElapsed < maxTime)
            {
                timeElapsed += Time.deltaTime;
                DisplayTime(timeElapsed);
            }
            else
            {
                Debug.Log("Time has run out!");
                //timeElapsed = interval;
                //timerIsRunning = false;
            }

            if (timeElapsed > 60) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 13f;                
            }
            else if (timeElapsed > 120) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 8f;                
            }
            else if (timeElapsed > 180) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 5f;                
            } 
            else if (timeElapsed > 240) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 3f;                
            }
            else if (timeElapsed > 300) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 2;                
            }
            else if (timeElapsed > 360) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 1f;                
            }
            else if (timeElapsed > 480) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 0.9f;                
            } 
            else if (timeElapsed > 540) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 0.8f;                
            }
            else if (timeElapsed > 600) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 0.7f;                
            }
            else if (timeElapsed > 660) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 0.6f;                
            }                                                                                                          
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}