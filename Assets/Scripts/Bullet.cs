using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 targetDir = Vector3.zero;
    float bulletSpeed = 10f;

    [SerializeField] AudioSource blastingSource;
    [SerializeField] AudioSource nothingSource;

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
        if (other.gameObject.CompareTag("TimeEfficent"))
            blastingSource.Play();
        else nothingSource.Play();
        print(other.name);
    }
}