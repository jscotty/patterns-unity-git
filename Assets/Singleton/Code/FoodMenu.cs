using System;
using UnityEngine;
using UnityEngine.UI;

/**
 * 2/8/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */
namespace Singleton.Code {
    public class FoodMenu : MonoBehaviour {
        [SerializeField] private Button[] _buttons;

        public Action<int> OnButtonPressed;

        private void Start() {
            for (int i = 0; i < _buttons.Length; i++) {
                var index = i; // caching index for action
                _buttons[i].onClick.AddListener(() => OnButtonPressed?.Invoke(index));
            }
        }

        public void DisableButtons() {
            for (int i = 0; i < _buttons.Length; i++) {
                _buttons[i].interactable = false;
            }
        }

        public void EnableButtons() {
            for (int i = 0; i < _buttons.Length; i++) {
                _buttons[i].interactable = true;
            }
        }
    }
}