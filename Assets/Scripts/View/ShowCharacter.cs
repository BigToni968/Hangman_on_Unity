using UnityEngine.UI;
using UnityEngine;

public interface IShowCharacterView
{
    public void Set(Texture characterTexture);
}

public class ShowCharacter : MonoBehaviour, IShowCharacterView
{
    [SerializeField] private RawImage _character;

    public void Set(Texture characterTexture)
    {
        _character.texture = characterTexture;
    }
}