using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputHandler {

    /// <summary>
    /// Get the player's input for horizontal camera movement
    /// </summary>
    /// <returns> float in the range [-1,1] where -1 relates to full left and 1 relates to full right</returns>
    public abstract float GetHorizontalCameraInput();

    /// <summary>
    /// Get the player's input for the jump action
    /// </summary>
    /// <returns>true if the action was pressed down this frame</returns>
    public abstract bool GetJumpInput();
}
