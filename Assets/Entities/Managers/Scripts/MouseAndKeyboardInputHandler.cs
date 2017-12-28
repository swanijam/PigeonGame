using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: Corwin Belser
/// <summary>
/// Input handler for a mouse and keyboard
/// </summary>
public class MouseAndKeyboardInputHandler : InputHandler {

    /// <summary>
    /// Get the player's input for horizontal camera movement using the mouse position
    /// </summary>
    /// <remarks>
    /// If the mouse is not confined to the game window, the value mousePosition can be outside the intended range
    /// https://docs.unity3d.com/ScriptReference/Input-mousePosition.html
    /// </remarks>
    /// <returns> float in the range [-1,1] where -1 relates to full left and 1 relates to full right</returns>
    public override float GetHorizontalCameraInput()
    {
        return 2 * Input.mousePosition.x / Screen.width - 1;
    }

    /// <summary>
    /// Get the player's input for the jump action
    /// </summary>
    /// <remarks>Went with the Spacebar as the jump button</remarks>
    /// <returns>true if the action was pressed down this frame</returns>
    public override bool GetJumpInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
