/*
 * Copyright (c) 2021 Gamepoint. All Rights Reserved.
 * 
 * Woe to the traitor who tries to penetrate my secrets and to stretch forth a sacrilegious
 * hand toward my code. May all calamities and disgrace fall on him! May hunger twist his
 * entrails, and sleep flee from his bloodshot eyes! May the hand of the man wither who
 * hastens to him with rescue and pities him in his misery! May the bread on his table turn
 * into rottenness, and the wine into stinking juice! May his children die out, and his house
 * be filled with bastards who will spit on him and expel him! May he die groaning through many
 * days in loneliness, and may neither earth nor water receive his vile carcass, may no fire burn
 * it, no wild beasts devour it! And may his soul, torn by its sins, wander without rest,
 * through dark places.
 */

using System;
using UnityEngine;
using UnityEngine.UI;

/**
 * 2/8/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */
namespace Facade.Code {
    public class FoodMenu : MonoBehaviour {
        // all buttons set in inspector
        [SerializeField] private Button[] _buttons;

        // set all buttons intractability to false
        public void DisableButtons() {
            for (int i = 0; i < _buttons.Length; i++) {
                _buttons[i].interactable = false;
            }
        }
        
        // set all buttons intractability to true
        public void EnableButtons() {
            for (int i = 0; i < _buttons.Length; i++) {
                _buttons[i].interactable = true;
            }
        }
    }
}