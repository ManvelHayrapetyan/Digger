using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // TestService
        Container.Bind<PlayerMovement>().FromComponentInHierarchy().AsSingle();
    }
}