using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TimeState currentState= TimeState.New;

    [SerializeField] FloorChanger floorChanger;

    private float playerDisablingTime = .5f;
    private float environmentChangingTime = 1f;
    private float playerEnablingTime = .5f;

    [SerializeField] GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        player.SetActive(false);
    }

    void ChangeEnvironment()
    {
        floorChanger.ChangeNewState(currentState);
    }

    void EnablePlayer()
    {
        player.SetActive(true);
    }
}
