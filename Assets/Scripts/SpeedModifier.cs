using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedModifierRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpeedModifierRoutine() {
        yield return new WaitForSeconds(0.8f);
        var velocityOverLifetime = this.GetComponent<ParticleSystem>().velocityOverLifetime;
        velocityOverLifetime.speedModifier = 0;
    }
}
