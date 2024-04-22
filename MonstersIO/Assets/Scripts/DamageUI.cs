using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DamageUI : MonoBehaviour
{
    public TMP_Text damageTxt;
    public float dissolveTime;

    private void Start()
    {
        float amount = Random.Range(-.5f, .5f);

        Vector2 moveVector = new Vector2(transform.position.x + amount, transform.position.y +1);

        transform.DOMove(moveVector, dissolveTime)

            .OnStart(delegate
            {
                GetComponent<CanvasGroup>().DOFade(0, dissolveTime).OnComplete(() => Destroy(gameObject));
            });
        
    }

    public void SetValue(float value)
    {
        damageTxt.text = value.ToString();
    }

}
