using UnityEngine;

/**
 * 2/13/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */
namespace Singleton.Code {
    // inherit from singleton to have global access
    public class GameManagerSingleton : Singleton<GameManagerSingleton> {
        // player preference key
        private const string HighScorePref = "HighScore";

        // score
        public int Score { get; private set; } = 0;

        // high score cached variable
        private int _highScore = 0;

        // high score getter which checks if current score should overwrite.
        public int HighScore {
            get {
                if (Score <= _highScore) {
                    return _highScore;
                }

                _highScore = Score;
                PlayerPrefs.SetInt(HighScorePref, HighScore);

                return _highScore;
            }
        }

        private void Start() {
            // get last saved high score from player preferences
            _highScore = PlayerPrefs.GetInt(HighScorePref);
        }

        // returns new score
        public int AddScore() {
            Score++;
            return Score;
        }

        // resets score to 0
        public void ResetScore() {
            Score = 0;
        }
    }
}