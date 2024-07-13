using Leopotam.EcsLite;

namespace Game.Counter
{
    public class CounterIncreaserInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            
            var counterIncreaserPool = world.GetPool<CounterIncreaserComponent>();
            counterIncreaserPool.Add(world.NewEntity());
            
            var counterPool = world.GetPool<CounterComponent>();
            counterPool.Add(world.NewEntity());
        }
    }
}