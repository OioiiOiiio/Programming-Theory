using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    InputAction _clickAction;
    void Start()
    {
        _clickAction = InputSystem.actions.FindAction("Attack");
    }
    void Update()
    {
        if (_clickAction.triggered) StartGame();
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
