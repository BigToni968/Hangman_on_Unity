using System.Collections.Generic;
using System.Text;

public interface IGameModel
{
    public string HideWord { get; }
    public int Show(string symbol);
    public void Hide();
    public bool WordOpened();
}

public class GameModel : IGameModel
{
    public string HideWord { get; private set; }
    private StringBuilder _builder;
    private string _word;

    public GameModel(string word)
    {
        _word = word;
    }

    public bool WordOpened() => _word.ToLower().Equals(HideWord.ToLower());

    public void Hide()
    {
        _builder ??= new StringBuilder(_word.Length);

        for (int i = 0; i < _word.Length; i++)
            _builder.Append("*");

        HideWord = _builder.ToString();
        _builder.Clear();
    }

    public int Show(string symbol)
    {
        List<int> indexs = new List<int>(_word.Length);
        int numberettersOpened = 0;

        for (int i = 0; i < _word.Length; i++)
            if (_word[i].ToString().ToLower() == symbol.ToLower())
                indexs.Add(i);

        if (indexs.Count != 0)
        {
            _builder.Clear();

            for (int i = 0; i < HideWord.Length; i++)
                _builder.Append(HideWord[i]);

            foreach (int index in indexs)
            {
                if (_builder[index] == '*')
                {
                    _builder[index] = symbol.ToCharArray()[0];
                    HideWord = _builder.ToString();
                    numberettersOpened++;
                }
            }
        }

        return numberettersOpened;
    }
}