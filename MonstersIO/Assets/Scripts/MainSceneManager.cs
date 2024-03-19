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
        if (!isOptionButtonClicked)
        {
            optionMenu.SetActive(true);
            optionMenu.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
            isOptionButtonClicked = true;
        }
        else if (isOptionButtonClicked)
        {
            optionMenu.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(delegate
            {
                optionMenu.SetActive(false);
            });
            isOptionButtonClicked = false;
        }
    }
}
