using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/**
 * 2/8/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */
namespace Singleton.Code {
    // to make sure we have an animator on this instance we add a require component attribute.
    [RequireComponent(typeof(Animator))]
    public class Sorcerer : MonoBehaviour {
        // to visualise which type of food we want to eat
        [SerializeField] private Text _targetLabel;

        // to trigger animations
        private Animator _anim;

        private int _currentTarget;

        // Two event actions we will listen to in Facade
        public event Action OnDied;
        public event Action OnSurvived;

        private void Start() {
            // get animator
            _anim = GetComponent<Animator>();

            // set target label alpha to 0
            _targetLabel.DOFade(0, 0);
        }

        // Set food type target
        public void SetTarget(int target, string foodString, Action onSetLabel) {
            _currentTarget = target;
            _targetLabel.text = $"Give me: {foodString}";

            // Fade in the text label asking the food type
            _targetLabel.DOFade(1, 0.2f).SetDelay(2).OnComplete(() => {
                // Fade out the text label so the user can't peak anymore what the sorcerer wants to eat.
                _targetLabel.DOFade(0, 0.1f).SetDelay(0.5f);

                // Call action to tell facade the question is visible! 
                onSetLabel?.Invoke();
            });
        }

        // Start eating progress and check whether we died or not
        public void Eat(int target) {
            _anim.SetTrigger("Eat");

            if (_currentTarget != target) {
                // Die after 3 seconds to make it exciting if the user choose right or wrong.
                DOVirtual.DelayedCall(3f, Die);
            }
            else {
                // Call survive event after 1.5 seconds to start whole process over.
                DOVirtual.DelayedCall(1.5f, () => OnSurvived?.Invoke());
            }
        }

        private void Die() {
            _anim.SetTrigger("Die");

            // call die event
            OnDied?.Invoke();
        }
    }
}