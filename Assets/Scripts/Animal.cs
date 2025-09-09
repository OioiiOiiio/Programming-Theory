using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Animal : MonoBehaviour
{
    // ENCAPSULATION
    public string Name {
        get => _name;
        set {
            if(value.Length <= 0 || value.Length > 10)
            {
                Debug.LogError("Name lenght must be more than 0 and lower than 10!");
                return;
            }
            _name = value;
        }
    }

    public TextMeshProUGUI _chat;
    // ABSTRACTION
    public abstract IEnumerator DisplayText();
    protected bool _textDisplay;

    InputAction _clickAction;
    [SerializeField]
    private string _name;

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
