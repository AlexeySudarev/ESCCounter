using Game.UI;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Counter
{
    public class CounterIncreaserSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _counterIncreaserFilter;
        private EcsPool<CounterIncreaserComponent> _counterIncreasers;

        private EcsFilter _counterFilter;
        private EcsPool<CounterComponent> _counters;

        private UIElementsService _uiElementsService;
        
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            
            _counterIncreaserFilter = world.Filter<CounterIncreaserComponent>().End();
            _counterIncreasers = world.GetPool<CounterIncreaserComponent>();

            _counterFilter = world.Filter<CounterComponent>().End();
            _counters = world.GetPool<CounterComponent>();

            _uiElementsService = ServiceLocator.GetService<UIElementsService>();
        }
        
        public void Run(IEcsSystems systems)
        {
            HandleCounterIncreasers();
        }

        private void HandleCounterIncreasers()
        {
            foreach (int counterIncreaser in _counterIncreaserFilter)
            {
                ref CounterIncreaserComponent counterIncreaserComponent = ref _counterIncreasers.Get(counterIncreaser);
                counterIncreaserComponent.Timer += Time.deltaTime;
                
                if (counterIncreaserComponent.Timer < counterIncreaserComponent.TimeToIncrease) continue;

                counterIncreaserComponent.Timer = 0;

                HandleCounters();
            }
        }

        private void HandleCounters()
        {
            foreach (int counter in _counterFilter)
            {
                ref CounterComponent counterComponent = ref _counters.Get(counter);
                counterComponent.Value++;
                
                Debug.Log(counterComponent.Value);
            }
        }
    }
}