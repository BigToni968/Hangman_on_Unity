using System.Collections;
using UnityEngine;
using System;

public interface IOpenSprite
{
    public int Opened { get; }
    public void SetOpen(int openIndex);
}

public interface IList<T>
{
    public int Count { get; }
    public IEnumerator List { get; }
    public T GetElement(int index);
}

[CreateAssetMenu(menuName = "DataBase")]
public class DataBase : ScriptableObject
{
    [field: SerializeField] public WordList Words { get; private set; }
    [field: SerializeField] public CharacterList Characters { get; private set; }

    [SerializeField] private OpenCharacters _openSprite;

    private OpenCharacters _runtimeOpenSprite;

    public IOpenSprite OpenSprite => _runtimeOpenSprite;

    [System.Serializable]
    public class WordList : IList<string>
    {
        [SerializeField] private string[] _words;

        public int Count => _words.Length;
        public IEnumerator List => _words.GetEnumerator();
        public string GetElement(int index) => _words[index];
    }

    [System.Serializable]
    public class CharacterList : IList<Sprite>
    {
        [SerializeField] private Sprite[] _spites;

        public int Count => _spites.Length;
        public IEnumerator List => _spites.GetEnumerator();
        public Sprite GetElement(int index) => _spites[index];
    }

    [System.Serializable]
    public class OpenCharacters : IOpenSprite, ICloneable
    {
        OpenCharacters(IOpenSprite open)
        {
            Opened = open.Opened;
        }

        [field: SerializeField]
        public int Opened { get; private set; }

        public object Clone()
        {
            return new OpenCharacters(this);
        }

        public OpenCharacters Dublicate()
        {
            return Clone() as OpenCharacters;
        }

        public void SetOpen(int openIndex)
        {
            Opened = openIndex;
        }
    }

    private void OnEnable()
    {
        _runtimeOpenSprite = _openSprite.Dublicate();
    }
}