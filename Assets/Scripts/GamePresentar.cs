using UnityEngine;


public interface IGamePresentar
{
    public void Execute();
}

public class GamePresentar : IGamePresentar
{
    private IGameModel _model;
    private IGameView _view;

    private IGameRules _rules;
    private IHideCharacterView _hideCharacter;
    private IShowCharacterView _showCharacter;
    private IList<Sprite> _characters;
    private IOpenSprite _openSprite;
    private INotificationView _notification;
    private IAttempsView _attempsView;

    public GamePresentar(IGameModel model,
        IGameView view,
        IGameRules rules,
        IHideCharacterView hide,
        IShowCharacterView show,
        IList<Sprite> characters,
        IOpenSprite openSprite,
        INotificationView notification,
        IAttempsView attempsView)
    {
        _model = model;
        _view = view;

        _rules = rules;
        _hideCharacter = hide;
        _showCharacter = show;
        _characters = characters;
        _openSprite = openSprite;
        _notification = notification;
        _attempsView = attempsView;
    }

    public void Execute()
    {
        _view.InputUser += UpdateView;
        _model.Hide();
        _view.Show(_model.HideWord);
        _showCharacter.Set(_characters.GetElement(_openSprite.Opened == _characters.Count ? _openSprite.Opened - 1 : _openSprite.Opened)?.texture);
        _hideCharacter.CreateLines(_model.HideWord.Length);
        _attempsView.Show(_rules.Attemps);
    }

    private void UpdateView(string symbol)
    {
        if (_rules.Attemps == 0)
            return;

        int letters = _model.Show(symbol);

        for (int i = 0; i < letters; i++)
        {
            _view.Show(_model.HideWord);
            _hideCharacter.RemoveLine();
        }

        if (letters == 0)
            _rules.Attemps -= 1;

        _attempsView.Show(_rules.Attemps);

        if (_model.WordOpened())
        {
            _rules.Attemps = _rules.DefaultAttemps;
            _openSprite.SetOpen(_openSprite.Opened + 1);
            _notification.Show(NotificationType.Win);
        }
        else if (_rules.Attemps == 0)
        {
            _rules.Attemps = _rules.DefaultAttemps;
            _notification.Show(NotificationType.Lose);
        }
    }
}