using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 targetDir = Vector3.zero;
    float bulletSpeed = 10f;

    public void Fire(Vector3 targetPos)
    {
        targetDir = targetPos.normalized;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(targetDir);

        transform.position += targetDir * bulletSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                break;
            case "TimeEfficent":
                SoundManager.Instance.BlastSound();
                ParticleManager.Instance.BlastParticle(transform);
                gameObject.SetActive(false);
                break;
            case "Enemy":
                print("enemyHit");
                EnemyManager.Instance.SpawnGraveyard(other.transform);
                ParticleManager.Instance.BlastParticle(other.transform);
                SoundManager.Instance.BlastSound();
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                break;
            default:
                SoundManager.Instance.NothingSound();
                gameObject.SetActive(false);
                break;
        }

    }
}