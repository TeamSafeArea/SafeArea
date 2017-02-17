using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEffect : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> m_particleContainer;

    private void OnEnable()
    {
        foreach (ParticleSystem p in m_particleContainer)
        {
            p.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_particleContainer[0].isPlaying == true) return;
        this.gameObject.SetActive(false);
    }
}
