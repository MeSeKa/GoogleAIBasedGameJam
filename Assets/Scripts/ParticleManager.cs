using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public static ParticleManager Instance { get; private set; }
    [SerializeField]private GameObject blastPrefab;
    [SerializeField] int particleCount = 5;

    public Queue<ParticleSystem> particles = new Queue<ParticleSystem>();

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < particleCount; i++)
        {
            var obj = Instantiate(blastPrefab);
            obj.SetActive(false);
            particles.Enqueue(obj.GetComponent<ParticleSystem>());  
        }
    }

    public void BlastParticle(Transform obj)
    {
        var particle = particles.Dequeue();
        particle.gameObject.transform.position = obj.position;
        particle.gameObject.SetActive(true);
        particle.Play();

        particles.Enqueue(particle);
    }
}

