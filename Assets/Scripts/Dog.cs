using System.Collections;
using UnityEngine;

public class Dog : Animal
{
    public override IEnumerator DisplayText()
    {
        if (_chat == null) Debug.LogError($"Missing chat field for {this.gameObject.name}");
        else
        {
            _chat.text = $"My name is {_name}, Woof!";
            _textDisplay = true;
            yield return new WaitForSeconds(3);
            _chat.text = string.Empty;
            _textDisplay = false;
        }
    }
}
