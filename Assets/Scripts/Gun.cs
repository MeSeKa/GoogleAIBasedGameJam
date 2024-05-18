using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float cooldown = 1f;
    float remainingCooldown = 1f;

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] Transform gunFiringPoint;


    Queue<Bullet> bulletQueue = new Queue<Bullet>();
    [SerializeField] int bulletCount = 5;

    AudioSource shootingSource;

    private void Awake()
    {
        gunFiringPoint = this.transform;

        for (int i = 0; i < bulletCount; i++)
        {
            var bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();
            bullet.gameObject.SetActive(false);
            bulletQueue.Enqueue(bullet);
        }

        this.shootingSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            remainingCooldown = cooldown;
        }
    }

    void Shoot()
    {
        var mouseClickPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseClickPosition, out RaycastHit hitInfo))
        {

            Vector3 bulletTargetPosition = hitInfo.point;

            var bullet = bulletQueue.Dequeue();
            bullet.transform.position = gunFiringPoint.position;
            bullet.gameObject.SetActive(true); 
            bulletQueue.Enqueue(bullet);

            bullet.Fire(bulletTargetPosition - gunFiringPoint.position);

            shootingSource.Play();
        }
    }
}
