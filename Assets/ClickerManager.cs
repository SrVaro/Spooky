using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{

    private int clicks = 0;
    [SerializeField] private Transform skeletonTf;
    [SerializeField] private SpriteRenderer skeletonSr;
    [SerializeField] private Transform step1;

    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    [SerializeField] private AudioSource audioPOP;

    [SerializeField] private TextMeshProUGUI clicksText;

    private IEnumerator coroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            clicks ++;
            
            if(clicks % 1 == 0) {
                if(step1.position != skeletonTf.position) {
                    skeletonTf.position += new Vector3(0, 0.1f, 0);
                } else {
                    StartCoroutine("PlayPOP",0.1f);
                }
            }
        
            clicksText.text = clicks.ToString();
        }
    }

     private IEnumerator PlayPOP(float waitTime)
    {
        audioPOP.Play();
        skeletonSr.sprite = sprite2;
        yield return new WaitForSeconds(waitTime);
        skeletonSr.sprite = sprite1;
    }

    
}
