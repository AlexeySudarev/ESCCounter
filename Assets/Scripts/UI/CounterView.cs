using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void UpdateCounter(int value)
        {
            _text.text = value.ToString();
        }
    }
}