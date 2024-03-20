using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Npc : MonoBehaviour
{
    public GameObject holdingMenu;
    private CanvasGroup menuCanvasGroup;


    private void Start()
    {
        menuCanvasGroup = holdingMenu.GetComponent<CanvasGroup>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ShowMenu();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HideMenu();
        }
    }

    private void ShowMenu()
    {
        holdingMenu.SetActive(true);
        menuCanvasGroup.DOFade(1, .5f);
    }

    private void HideMenu()
    {
        menuCanvasGroup.DOFade(0, .5f).OnComplete(() =>
        {
            holdingMenu.SetActive(false);
        });
    }

}
