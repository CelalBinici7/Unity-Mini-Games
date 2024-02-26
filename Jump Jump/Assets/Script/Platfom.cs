using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Platfom : MonoBehaviour
{
    public GameObject[] spawnsoints;
    public GameObject prefab;
    public GameObject character;
    public Dictionary<GameObject,bool> pointsUsed = new();
    public List<GameObject> enablePrefab = new();
    public HealthSystem healthSystem;
    int chose;
    float objectCount;

    [Header("Timer")]
    public TMP_Text timeText;
    public Image slider;
    float time;
    bool startTimer;
    public bool inMinutes;
    public float timeLimit = 60f;
  
    Coroutine crt;
    Coroutine crt2;
    void Start()
    {
        timeText.text = timeLimit.ToString();
        time = timeLimit;
        startTimer = true;
        
        foreach (var p in spawnsoints)
        {
            if (p!=null&& spawnsoints != null)
            {
                pointsUsed.Add(p, false);
            }
         
        }
        SpawnObject();

    }

    // Update is called once per frame
    void Update()
    {
        if (!startTimer) return;
        if (time > 0)
        {

            time -= Time.deltaTime;
            timeText.text = Mathf.CeilToInt(time).ToString();
        }
        

        if (time <=0 && healthSystem.health==0)
        {
            //WONNNN
        }
      
    }

    public void StartTimer()
    {
       
        startTimer = true;
      
      
    }
    public void StopTimer()
    {
        if (startTimer)
        {
            startTimer = false;
        }
    }
    public void RestartTimer()
    {
        time = timeLimit;
        timeText.text = time.ToString();
      
    }
  
    public void SpawnObject()
    {
        
        objectCount = Random.Range(5, 10);

        for (int i = 0; i < objectCount; i++)
        {
            chose = Random.Range(0, 28);
            if (pointsUsed[spawnsoints[chose]]==false)
            {
                pointsUsed[spawnsoints[chose]] = true;
                GameObject item=Instantiate(prefab, spawnsoints[chose].transform.position, Quaternion.identity, spawnsoints[chose].transform);
                enablePrefab.Add(item);
            }

        }

    }
    public void ResetSpawnObjects()
    {
        foreach (var item in enablePrefab) 
        {
            item.gameObject.SetActive(false);
        }
        List<GameObject> keysToUpdate = new List<GameObject>(pointsUsed.Keys);
        foreach (GameObject item in keysToUpdate)
        {
            pointsUsed[item] = false;
        }
    }
    
    IEnumerator functionCorotune()
    {
        SpawnObject();
        yield return null;
        StopCoroutine(crt);
    }  IEnumerator functionCorotune2()
    {
        ResetSpawnObjects();
        yield return null;
        StopCoroutine(crt2);
    }
   
    public void change()
    {
        crt2 = StartCoroutine(functionCorotune2());
        crt = StartCoroutine(functionCorotune());
    }
}
