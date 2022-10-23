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
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 18f;                
            }
            else if (timeElapsed > 120) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 16f;                
            }
            else if (timeElapsed > 180) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 14f;                
            } 
            else if (timeElapsed > 240) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 12f;                
            }
            else if (timeElapsed > 300) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 10f;                
            }
            else if (timeElapsed > 360) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 8f;                
            }
            else if (timeElapsed > 480) {
                GameObject.Find("GroupSpawner").GetComponent<GroupSpawner>().startTimeBtwSpawn = 6f;                
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