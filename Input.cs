using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNAInput {
    class Input {
        private static Keys[] lastKeyState = new Keys[] { },
                              curKeyState = new Keys[] { };

        private static MouseState lastMouseState,
                                  curMouseState;

        public static Vector2 MousePosition {
            get {
                return new Vector2(curMouseState.X, curMouseState.Y);
            }
        }

        public static void UpdateState() {
            if (curKeyState == null)
                lastKeyState = curKeyState;
            curKeyState = Keyboard.GetState().GetPressedKeys();

            lastMouseState = curMouseState;
            curMouseState = Mouse.GetState();
        }

        public static bool MouseLeft() {
            return curMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool MouseLeftUp() {
            return curMouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool MouseLeftDown() {
            return curMouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released;
        }

        public static bool MouseMiddle() {
            return curMouseState.MiddleButton == ButtonState.Pressed;
        }

        public static bool MouseMiddleUp() {
            return curMouseState.MiddleButton == ButtonState.Released && lastMouseState.MiddleButton == ButtonState.Pressed;
        }

        public static bool MouseMiddleDown() {
            return curMouseState.MiddleButton == ButtonState.Pressed && lastMouseState.MiddleButton == ButtonState.Released;
        }

        public static bool MouseRight() {
            return curMouseState.RightButton == ButtonState.Pressed;
        }

        public static bool MouseRightUp() {
            return curMouseState.RightButton == ButtonState.Released && lastMouseState.RightButton == ButtonState.Pressed;
        }

        public static bool MouseRightDown() {
            return curMouseState.RightButton == ButtonState.Pressed && lastMouseState.RightButton == ButtonState.Released;
        }

        public static bool anyKey {
            get {
                return curKeyState.Length > 0;
            }
        }

        public static bool anyKeyDown {
            get {
                return curKeyState.Except(lastKeyState).Count() > 0;
            }
        }

        public static bool GetKey(Keys key) {
            return curKeyState.Contains(key);
        }

        public static bool GetKeyDown(Keys key) {
            return curKeyState.Except(lastKeyState).Contains(key);
        }

        public static bool GetKeyUp(Keys key) {
            return lastKeyState.Except(curKeyState).Contains(key);
        }
    }
}