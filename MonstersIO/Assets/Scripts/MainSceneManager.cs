using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainSceneManager : MonoBehaviour
{

    public Button coverButton;

    public void CoverButtonOnClick()
    {
        coverButton.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(delegate
        {
            coverButton.gameObject.SetActive(false);
        });
    }
}
