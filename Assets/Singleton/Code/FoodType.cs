/*
 * 2/13/2021
 *
 * @author Justin Scotty 01001010 01010011 01000010
 */

using UnityEngine;

namespace Singleton.Code {
    // making this struct serializable so it's visible in the editor inspector
    [System.Serializable]
    public struct FoodType {
        public string Name;
        public Sprite Icon;
    }
}