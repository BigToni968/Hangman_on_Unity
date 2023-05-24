using UnityEngine;
using TMPro;

public interface IGameView
{
    public delegate void InputUserHandler(string symbo);
    public event InputUserHandler InputUser;

    public void Show(string hideWord);
}

public class GameView : MonoBehaviour, IGameView
{
    [SerializeField] private TextMeshProUGUI _output;
    [SerializeField] private TMP_InputField _input;

    public event IGameView.InputUserHandler InputUser;

    public void Show(string hideWord)
    {
        _output.SetText(hideWord);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!string.IsNullOrEmpty(_input.text))
                InputUser?.Invoke(_input.text);

            _input.text = null;
        }
    }
}