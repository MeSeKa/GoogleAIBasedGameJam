using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class RandomPlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private bool canMove = true;
    private Vector3 direction;

    public void SetCanMove(bool set)
    {
        canMove = set;
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }

    private void Update()
    {
        if (canMove)
            transform.position += direction * moveSpeed * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false;
        }
    }
}
