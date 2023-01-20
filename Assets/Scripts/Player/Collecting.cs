using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public AudioSource pickupFX;
    public GameObject collectlight;
    public GameObject model;

    void OnTriggerEnter(Collider other)
    {
        PlayerDistance.Instance.disAdded += 100f;
        Destroy(collectlight);
        Destroy(model);
        pickupFX.Play();
        Destroy(gameObject, 5f);
    }


}
