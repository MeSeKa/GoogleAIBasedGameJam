using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    [SerializeField] PlayerSingleton singleton;
    public static PlayerSingleton Instance {  get; private set; }


    private void Awake()
    {
        Instance = this;
    }

}
