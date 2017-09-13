using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

    public void Quit()  // need to be public so they can be addressed by the onClick event
    {

        //we're going to make it behave differently
        //depending on whenther its in unity edditor or not
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
