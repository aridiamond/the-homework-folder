using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeload : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Object.Destroy(GameObject.FindWithTag("Env"), 2f);
    }
}
