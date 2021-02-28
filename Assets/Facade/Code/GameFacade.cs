using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/**
 * 2/8/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */
namespace Facade.Code {
    public class GameFacade : MonoBehaviour {
        // access points
        [SerializeField] private FoodType[] Targets;
        [SerializeField] private Sorcerer sorcerer;
        [SerializeField] private FoodMenu _foodMenu;
        [SerializeField] private Button _reset;
        [SerializeField] private Image _foodIcon;

        // current target
        private int _target = -1;

        private void Start() {
            // initializing objects
            _reset.onClick.AddListener(Reset);
            _reset.gameObject.SetActive(false);

            // listening to sorcerer events
            sorcerer.OnSurvived += RandomTarget;
            sorcerer.OnDied += OnEnemyDied;

            // disabling all buttons on start
            _foodMenu.DisableButtons();

            // set a random target
            RandomTarget();
        }

        private void RandomTarget() {
            // get a random target number
            _target = Random.Range(0, Targets.Length);

            // set sorcerer target to start label animation
            // enable all buttons once target is set.
            sorcerer.SetTarget(_target, Targets[_target].Name, _foodMenu.EnableButtons);
        }

        // Called by button onclick events in editor.
        public void Eat(int target) {
            // disable all buttons
            _foodMenu.DisableButtons();

            // set food icon sprite, which will be animated by sorcerer .Eat method
            _foodIcon.sprite = Targets[target].Icon;

            // start eat animation
            sorcerer.Eat(target);
        }

        private void OnEnemyDied() {
            // enable reset button when enemy died
            _reset.gameObject.SetActive(true);
        }

        private void Reset() {
            sorcerer.OnSurvived -= RandomTarget;
            sorcerer.OnDied -= OnEnemyDied;

            // reset current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}