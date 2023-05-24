using UnityEngine;
using Zenject;

public class FirstInstaller : MonoInstaller<FirstInstaller>
{
    [SerializeField]
    private SceneExplorer _explorer;

    [SerializeField]
    private DataBase _data;

    public override void InstallBindings()
    {
        ProjectContext.Instance.Container.BindInstance<IList<string>>(_data.Words).WithId("Words").AsCached();
        ProjectContext.Instance.Container.BindInstance<IList<Sprite>>(_data.Characters).WithId("Characters").AsCached();
        ProjectContext.Instance.Container.BindInstance<IOpenSprite>(_data.OpenSprite).AsSingle();
    }

    new private void Start()
    {
        _explorer.Next();
    }
}