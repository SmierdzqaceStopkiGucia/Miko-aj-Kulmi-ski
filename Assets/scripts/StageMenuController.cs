using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class StageMenuController : MonoBehaviour
{
    public void OnOBlockClick()
    {
        SceneManager.LoadScene("OBlock");
    }

    public void OnBlastHazardClick()
    {
        SceneManager.LoadScene("BlastHazard");
    }

}
