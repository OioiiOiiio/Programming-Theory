using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Animal : MonoBehaviour
{
    public string _name;
    public TextMeshProUGUI _chat;
    public abstract IEnumerator DisplayText();
    protected bool _textDisplay;

    InputAction _clickAction;

    private void Start()
    {
        _clickAction = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        if (_clickAction.triggered && CheckHit()) {
            OnMouseClick();
        }
    }

    private bool CheckHit()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit2D = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit2D.collider != null)
        {
            return hit2D.collider.gameObject == this.gameObject;
        }
               
        return false;
    }

    private void OnMouseClick()
    {
        Debug.Log($"Mouse clicked on {this.gameObject.name}");
        if( _textDisplay == false ) StartCoroutine(DisplayText());
    }
}
