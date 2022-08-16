using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class LevelNumber : MonoBehaviour
    {
        public Text Text;
        public Text Text2;
        public Game Game;

        private void Start()
        {
            Text.text = (Game.LevelIndex + 1).ToString();
            Text2.text = (Game.LevelIndex + 2).ToString();
        }

    }
}