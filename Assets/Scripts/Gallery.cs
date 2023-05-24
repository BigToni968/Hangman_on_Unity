using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

public class Gallery : MonoBehaviour
{
    [SerializeField] private RawImage _characterPrefab;
    [SerializeField] private Transform _content;

    private List<RawImage> _images;
    private IList<Sprite> _sprites;
    private IOpenSprite _open;

    [Inject]
    private void Construct(IList<Sprite> list, IOpenSprite open)
    {
        _sprites = list;
        _open = open;
        _images = new List<RawImage>(list.Count);
    }

    private void OnEnable()
    {
        for (int i = 0; i < Mathf.Clamp(_open.Opened, 0, _sprites.Count); i++)
        {
            RawImage image = Instantiate(_characterPrefab, _content);
            image.texture = _sprites.GetElement(i).texture;
            image.name = _sprites.GetElement(i).name;
            _images.Add(image);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _images.Count; i++)
            Destroy(_images[i].gameObject);

        _images.Clear();
    }
}