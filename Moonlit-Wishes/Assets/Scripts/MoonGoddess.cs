using System.Collections;
using UnityEngine;
public class MoonGoddess : MonoBehaviour

{

    public ParticleSystem goddessHealEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    public void MoonGoddessParticleAffect()
    {
        if (goddessHealEffect == true)
        {
            float duration = goddessHealEffect.GetComponent<ParticleSystem>().main.duration;
            Instantiate(goddessHealEffect,this.transform.position, Quaternion.identity);
        }
    }

}
