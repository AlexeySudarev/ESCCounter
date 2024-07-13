using Game.Counter;
using Game.UI;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class GameStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            InitServices();
            InitECS();
        }

        private void InitServices()
        {
            ServiceLocator.AddService(new UIElementsService());
        }

        private void InitECS()
        {
            _world = new EcsWorld();
            
            _systems = new EcsSystems(_world);
            _systems
                .Add(new CounterIncreaserInitSystem())
                .Add(new CounterIncreaserSystem()).Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}