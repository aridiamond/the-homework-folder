using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    public float PlayerZPos => PlayerMove.Instance.transform.position.z;

    void Update()
    {
      
        if (PlayerZPos >= (zPos - 300))
        {
          secNum = Random.Range(0, section.Length);
          Instantiate(section[secNum], new Vector3(0,0,zPos), Quaternion.identity);
          zPos += 50;
        }
    }
}
