using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] GameObject[] section;
    private int zPos = 50;
    private int secNum;
    private float PlayerZPos => PlayerMove.Instance.transform.position.z;

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
