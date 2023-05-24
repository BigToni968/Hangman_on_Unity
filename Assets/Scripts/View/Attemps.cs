using UnityEngine;
using TMPro;

public interface IAttempsView
{
    public void Show(int numberAttmps);
}

public class Attemps : MonoBehaviour, IAttempsView
{
    [SerializeField] private TextMeshProUGUI _output;

    public void Show(int numberAttmps)
    {
        _output.SetText($"У вас есть {numberAttmps} попыток, чтобы отгадать слово!");
    }
}