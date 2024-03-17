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
            holdingMenu.SetActive(true);
            menuCanvasGroup.DOFade(1, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            menuCanvasGroup.DOFade(0f, .5f).OnComplete(delegate
            {
                holdingMenu.SetActive(false);
            });

            
        }
    }

}
