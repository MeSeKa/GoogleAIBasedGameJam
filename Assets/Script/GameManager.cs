using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private TimeState currentState = TimeState.New;

    [SerializeField] FloorChanger floorChanger;
    [SerializeField] Crane crane;

    private float playerDisablingTime = 1f;
    private float environmentChangingTime = 1f;
    private float playerEnablingTime = 1f;

    [SerializeField] GameObject player;

    private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            FullTimeChange();
        }
    }

    public void FullTimeChange()
    {
        ChangeState();

        DisablePlayer();
        Invoke("ChangeEnvironment", playerDisablingTime);
        Invoke("EnablePlayer", playerDisablingTime + environmentChangingTime);
        Invoke("Finish", playerDisablingTime + environmentChangingTime + playerEnablingTime);

    }

    void ChangeState()
    {
        switch (currentState)
        {
            case TimeState.Old:
                currentState = TimeState.New;
                break;
            case TimeState.New:
                currentState = TimeState.Old;
                break;

        }
    }

    void DisablePlayer()
    {
        crane.Show();
        crane.TakePlayer();
        player.GetComponent<ThirdPersonController>().enabled = false;
        player.GetComponent<CharacterController>().enabled = true;
    }

    void ChangeEnvironment()
    {
        //crane.DeShow();
        floorChanger.ChangeNewState(currentState);
    }

    void EnablePlayer()
    {
        //crane.Show();
        crane.ReleasePlayer();
    }

    void Finish()
    {
        crane.DeShow();
        player.GetComponent<ThirdPersonController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
    }


    public void AddToMainFloor(GameObject obj)
    {
        obj.transform.parent = floorChanger.transform;
    }
}
