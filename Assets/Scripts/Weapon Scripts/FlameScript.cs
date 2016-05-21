﻿using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {

    public float bulletSpeed = 4f;
    public int flameLife = 0;
   // public ParticleAnimator particleFire;

    // Use this for initialization
    void Start()
    {
        
        /*{
            particleFire = GetComponent<ParticleAnimator>();
            Color[] aniColors = particleFire.colorAnimation;

            for (int i = 0; i < aniColors.Length; i++)
            {
                aniColors[i].r = Random.Range(1.0f, 1.0f);
                aniColors[i].g = Random.Range(0.0f, 1.0f);
                aniColors[i].b = Random.Range(0.0f, 0.0f);
                aniColors[i].a = Random.Range(1.0f, 1.0f);
            }
            particleFire.colorAnimation = aniColors;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        ++flameLife;
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        if(flameLife == 60)
        {
            Destroy(gameObject);
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        print("destroying bullet");
        Destroy(gameObject);
    }*/
}