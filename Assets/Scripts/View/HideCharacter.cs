using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public interface IHideCharacterView
{
    public void CreateLines(int amountLines);
    public void RemoveLine();
}

public class HideCharacter : MonoBehaviour, IHideCharacterView
{
    [SerializeField] private float _timeAnimation;
    [SerializeField] private float _maxHeaight;
    [SerializeField] protected float _lineBonusHeight;
    [SerializeField] private RawImage _hideLine;
    [SerializeField] private VerticalLayoutGroup _layoutGroup;

    private List<RawImage> _lines;
    private WaitForSeconds _wait;

    private void OnGUI()
    {
        _layoutGroup.childControlWidth = false;
    }

    public void CreateLines(int amountLines)
    {
        float heightLine = _maxHeaight / amountLines;
        heightLine += _lineBonusHeight;
        _lines = new List<RawImage>(amountLines);

        for (int i = 0; i < amountLines; i++)
        {
            RawImage line = Instantiate(_hideLine, _layoutGroup.transform);
            line.rectTransform.sizeDelta = new Vector2(_hideLine.rectTransform.sizeDelta.x, heightLine);
            _lines.Add(line);
        }
    }

    public void RemoveLine()
    {
        RawImage line = _lines[Random.Range(0, _lines.Count)];
        _lines.Remove(line);
        _wait ??= new WaitForSeconds(_timeAnimation / line.rectTransform.sizeDelta.x);
        StartCoroutine(LineAnimation(line));
    }

    private IEnumerator LineAnimation(RawImage line)
    {
        float time = 0;
        Vector2 size = new Vector2(line.rectTransform.sizeDelta.x, line.rectTransform.sizeDelta.y);

        while (time < _timeAnimation)
        {
            time += Time.deltaTime;
            size.x -= 50;
            line.rectTransform.sizeDelta = size;
            yield return _wait;
        }

        size.x = 0;
        line.rectTransform.sizeDelta = size;
    }
}