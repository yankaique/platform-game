using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animator animator;
    public KeyCode keyToTrigger = KeyCode.A;

    public KeyCode keyToExit= KeyCode.S;
    public string triggerToPlay = "Fly";

    private void Update()
    {
        if (Input.GetKeyDown(keyToTrigger))
        {
            animator.SetBool(triggerToPlay, true);
        }else if (Input.GetKeyUp(keyToExit))
        {
            animator.SetBool(triggerToPlay, false);
        }
    }
}
