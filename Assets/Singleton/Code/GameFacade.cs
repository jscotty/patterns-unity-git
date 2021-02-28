using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/**
 * 2/8/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */
namespace Singleton.Code {
    public class GameFacade : MonoBehaviour {
        // text prefixes
        private const string ScoreText = "Score: ";
        private const string HighScoreText = "HighScore: ";

        [SerializeField] private FoodType[] Targets;
        [SerializeField] private Sorcerer sorcerer;
        [SerializeField] private FoodMenu _foodMenu;
        [SerializeField] private Button _reset;
        [SerializeField] private Image _foodIcon;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _highScoreText;

        // game started boolean to prevent updates on initial call
        private bool _gameStarted = false;
        private int _target = -1;

        private void Start() {
            // initializing objects
            _reset.onClick.AddListener(Reset);
            _reset.gameObject.SetActive(false);

            // listening to sorcerer events
            sorcerer.OnSurvived += RandomTarget;
            sorcerer.OnDied += OnEnemyDied;

            // initialize texts
            _scoreText.text = ScoreText + GameManagerSingleton.Instance.Score;
            _highScoreText.gameObject.SetActive(false);

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
            sorcerer.SetTarget(_target, Targets[_target].Name, OnEnemySurvived);
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

        private void OnEnemySurvived() {
            _foodMenu.EnableButtons();
            
            // added check so score does not update while game hasn't been fully initialized.
            if (_gameStarted) {
                _scoreText.text = ScoreText + GameManagerSingleton.Instance.AddScore();
            }

            // to make sure score doesn't get updated on first call
            _gameStarted = true;
        }

        private void OnEnemyDied() {
            // enable reset button when enemy died
            _reset.gameObject.SetActive(true);

            // refresh highscore text
            _highScoreText.text = HighScoreText + GameManagerSingleton.Instance.HighScore;
            // enable highscore text
            _highScoreText.gameObject.SetActive(true);
        }

        private void Reset() {
            // remove listeners
            sorcerer.OnSurvived -= RandomTarget;
            sorcerer.OnDied -= OnEnemyDied;

            // reset current scene and score
            GameManagerSingleton.Instance.ResetScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}