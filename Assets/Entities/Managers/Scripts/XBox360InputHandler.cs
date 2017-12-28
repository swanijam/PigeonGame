using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Author: Corwin Belser
/// <summary>
/// Input handler for the XBox360 controller
/// </summary>
/// <remarks>
/// I didn't implement this yet...because I'm lazy
/// http://wiki.unity3d.com/index.php?title=Xbox360Controller
/// https://blogs.msdn.microsoft.com/uk_faculty_connection/2014/12/02/adding-xbox-controller-support-and-input-to-your-unity3d-game/
/// </remarks>
public class XBox360InputHandler : InputHandler {

    /// <summary>
    /// Get the player's input for horizontal camera movement
    /// </summary>
    /// <returns> float in the range [-1,1] where -1 relates to full left and 1 relates to full right</returns>
    public override float GetHorizontalCameraInput()
    {
        //TODO: Implement this :(
        return 0f;
    }

    /// <summary>
    /// Get the player's input for the jump action
    /// </summary>
    /// <returns>true if the action was pressed down this frame</returns>
    public override bool GetJumpInput()
    {
        //TODO: Implement this :(
        return false;
    }
}
