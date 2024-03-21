using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainSceneManager : MonoBehaviour
{
    public Button coverButton;
    public GameObject optionMenu;
    [HideInInspector]public bool isOptionButtonClicked;

    public void CoverButtonOnClick()
    {
        coverButton.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(delegate
        {
            coverButton.gameObject.SetActive(false);
        });
    }

    public void OptionsButtonOnClick()
    {
        isOptionButtonClicked = !isOptionButtonClicked;
        float targetAlpha = isOptionButtonClicked ? 1f : 0f;

        optionMenu.SetActive(true);
        optionMenu.GetComponent<CanvasGroup>().DOFade(targetAlpha, 0.5f).OnComplete(() =>
        {
            if (!isOptionButtonClicked)
                optionMenu.SetActive(false);
        });
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
