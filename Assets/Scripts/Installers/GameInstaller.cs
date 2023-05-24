using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameRules _gameRules;
    [SerializeField] private HideCharacter _hideCharacter;
    [SerializeField] private ShowCharacter _showCharacter;
    [SerializeField] private Notification _notification;
    [SerializeField] private Attemps _attemps;
    [SerializeField] private GameView _gameView;

    public override void InstallBindings()
    {
        IList<string> words = ProjectContext.Instance.Container.ResolveId<IList<string>>("Words");
        IList<Sprite> sprites = ProjectContext.Instance.Container.ResolveId<IList<Sprite>>("Characters");
        IOpenSprite openSprite = ProjectContext.Instance.Container.Resolve<IOpenSprite>();

        Container.BindInstance<IList<string>>(words).WithId("Words").AsCached();
        Container.BindInstance<IList<Sprite>>(sprites).WithId("Characters").AsCached();
        Container.BindInstance<IOpenSprite>(openSprite).AsSingle();
        Container.BindInstance<IGameRules>(_gameRules).AsSingle();
        Container.BindInstance<IHideCharacterView>(_hideCharacter).AsSingle();
        Container.BindInstance<IShowCharacterView>(_showCharacter).AsSingle();
        Container.BindInstance<IGameView>(_gameView).AsSingle();
        Container.BindInstance<INotificationView>(_notification).AsSingle();
        Container.BindInstance<IAttempsView>(_attemps).AsSingle();
    }
}