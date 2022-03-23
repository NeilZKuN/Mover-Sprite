using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace KeyBoard_Manager_Project
{
    class KeyBoardManager
    {
        private static KeyBoardManager instance;
        enum KeyState 
        {
            PRESSED,
            HELD,
            UP,
            NONE
        }

        Dictionary<Keys, KeyState> keysandState;

        public KeyBoardManager() 
        {
            if (instance == null)
            {
                keysandState = new Dictionary<Keys, KeyState>();
                instance = this;
            }
            else
            {
                throw new Exception("Instance already created");
            }


            keysandState = new Dictionary<Keys, KeyState>();
        }

        public void Update() 
        {
            KeyboardState state = Keyboard.GetState();
            Keys[] pressedKeys = state.GetPressedKeys();

            foreach (Keys k in pressedKeys)
            {
                if (!keysandState.ContainsKey(k))
                {
                    keysandState.Add(k, KeyState.PRESSED);
                }
                else
                {
                    if (keysandState[k] == KeyState.PRESSED)
                    {
                        keysandState[k] = KeyState.HELD;
                    }
                }
            }

            foreach (Keys k in keysandState.Keys.ToArray())
            {
                if (!pressedKeys.Contains(k))
                {
                    if (keysandState[k] == KeyState.UP)
                    {
                        keysandState[k] = KeyState.NONE;
                    }
                    else if (keysandState[k] == KeyState.PRESSED || keysandState[k] == KeyState.HELD)
                    {
                        keysandState[k] = KeyState.UP;
                    }
                }
            }
        }

        bool IsKeyPressed(Keys k) => keysandState.ContainsKey(k) && keysandState[k] == KeyState.PRESSED;
        bool ISKeyUp(Keys k) => keysandState.ContainsKey(k) && keysandState[k] == KeyState.UP;
        bool ISKeyHeld(Keys k) => keysandState.ContainsKey(k) && keysandState[k] == KeyState.HELD;
    }
}
