using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundEffect : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip clip;
    private void Awake()
    {
        foreach (Button obje in Resources.FindObjectsOfTypeAll<Button>()) // butona bas�ld���n� kontrol ediyor.
        {
            obje.onClick.AddListener(() => MakeSound());
        }
    }
    public void MakeSound()
    {
        soundSource.PlayOneShot(clip);
    }
}
