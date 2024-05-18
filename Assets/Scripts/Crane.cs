using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] GameObject player;
    Transform previousTransform;

    [SerializeField] Animator animator;

    [SerializeField] float yOffset = 3f;

    [SerializeField] GameObject leftHand;
    [SerializeField] GameObject rightHand;

    private void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void AttachPlayer()
    {
        previousTransform = player.transform.parent;
        player.transform.parent = transform;
    }

    public void DetachPlayer()
    {
        player.transform.parent = previousTransform;
    }

    public void TakePlayer()
    {
        transform.parent.position = player.transform.position + new Vector3(0, yOffset, 0);
        transform.parent.rotation = Quaternion.LookRotation(player.transform.forward);
        animator.SetTrigger("TakePlayer");
    }

    public void ReleasePlayer()
    {
        animator.SetTrigger("ReleasePlayer");
    }

    public void Show()
    {
        leftHand.SetActive(true);
        rightHand.SetActive(true);
    }

    public void DeShow()
    {
        leftHand.SetActive(false);
        rightHand?.SetActive(false);
    }
}
