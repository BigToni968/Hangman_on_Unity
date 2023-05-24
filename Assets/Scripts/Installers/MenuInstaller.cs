using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        IList<Sprite> sprites = ProjectContext.Instance.Container.ResolveId<IList<Sprite>>("Characters");
        IOpenSprite openSprite = ProjectContext.Instance.Container.Resolve<IOpenSprite>();

        Container.BindInstance<IList<Sprite>>(sprites).AsSingle();
        Container.BindInstance<IOpenSprite>(openSprite).AsSingle();
    }
}