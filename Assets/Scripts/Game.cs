using UnityEngine;
using Zenject;

public class Game : MonoBehaviour
{
    private IGameView _view;
    private IList<string> _words;
    private IList<Sprite> _characters;
    private IGameRules _rules;
    private IHideCharacterView _hideCharacter;
    private IShowCharacterView _showCharacter;
    private IOpenSprite _openSprite;
    private INotificationView _notificationView;
    private IAttempsView _attempsView;


    [Inject]
    public void Construct(IGameView view,
        [Inject(Id = "Words")] IList<string> words,
        IGameRules rules,
        IHideCharacterView hide,
        IShowCharacterView show,
        [Inject(Id = "Characters")] IList<Sprite> characters,
        IOpenSprite openSprite,
        INotificationView notification,
        IAttempsView attempsView)
    {
        _view = view;
        _words = words;
        _rules = rules;
        _hideCharacter = hide;
        _showCharacter = show;
        _characters = characters;
        _openSprite = openSprite;
        _notificationView = notification;
        _attempsView = attempsView;
    }

    private void Start()
    {
        IGamePresentar game = new GamePresentar(
            new GameModel(_words.GetElement(Random.Range(0, _words.Count))),
            _view,
            _rules,
            _hideCharacter,
            _showCharacter,
            _characters,
            _openSprite,
            _notificationView,
            _attempsView);

        game.Execute();
    }
}