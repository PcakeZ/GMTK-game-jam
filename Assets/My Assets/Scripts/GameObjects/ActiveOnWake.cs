using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnWake : MonoBehaviour
{
    public GameObject fader;

    private void Awake()
    {
        fader.SetActive(true);
    }
}
