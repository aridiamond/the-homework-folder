using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public int generatedSections = 1;

    void Update()
    {
      if (creatingSection == false)  
      {
        creatingSection = true;
        StartCoroutine(GenerateSection());
      }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, section.Length);
        Instantiate(section[secNum], new Vector3(0,0,zPos), Quaternion.identity);
        generatedSections += 1;
        zPos += 50;
        if (generatedSections <= 10)
        {
          yield return new WaitForSeconds(2);
        }
        else
        {
          yield return new WaitForSeconds(4);
        }
        creatingSection = false;
    }
}
