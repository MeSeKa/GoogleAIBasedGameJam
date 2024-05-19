using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }

    [SerializeField] GameObject start;

    [SerializeField] GameObject end;
    [SerializeField] float transitionTime=.75f;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        end.SetActive(false);
        start.SetActive(true);
        Invoke("DeactiveStart", transitionTime);
    }

    public void DeactiveStart()
    {
        start.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    public void Restart()
    {
        end.SetActive(true);
        Invoke("EndScene", transitionTime);
    }

    public void EndScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
