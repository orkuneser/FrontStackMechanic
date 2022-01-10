using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectedManager : MonoBehaviour
{
    public List<GameObject> collectedMoney;

    #region SINGLETON
    public static CollectedManager instance;

    private void Awake()
    {
        instance = this;

    }
    #endregion

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveMoneyFollow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MoneyPositionFixed();
        }
    }
    public void StackMoney(GameObject gameObject, int index)
    {
        gameObject.transform.parent = this.transform;
        Vector3 newPos = collectedMoney[index].transform.localPosition;


        newPos.z +=1;

        gameObject.transform.localPosition = newPos;
        collectedMoney.Add(gameObject);
        StartCoroutine(CollectedMoneyStack());
    }

    // Objelerin Büyüp/Küçülmesini Saðlar
    private IEnumerator CollectedMoneyStack()
    {
        for (int i = collectedMoney.Count - 1; i > 0; i--)
        {
            Vector3 defaultScale = new Vector3(1, 1, 1);
            defaultScale *= 1.5f;
            collectedMoney[i].transform.DOScale(defaultScale, 0.1f).OnComplete(() =>
             collectedMoney[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f));

            yield return new WaitForSeconds(0.05f);
        }
    }

    // Toplanan Objelerin Lerp Hareket Mekaniði
    private void MoveMoneyFollow()
    {
        for (int i = 1; i < collectedMoney.Count; i++)
        {
            Vector3 Pos = collectedMoney[i].transform.localPosition;
            Pos.x = collectedMoney[i - 1].transform.localPosition.x;
            collectedMoney[i].transform.DOLocalMove(Pos,0.25f);

        }
    }

    // Objelerin Dizilimini Saðlar
    private void MoneyPositionFixed()
    {
        for (int i = 1; i < collectedMoney.Count; i++)
        {
            Vector3 Pos = collectedMoney[i].transform.localPosition;
            Pos.x = collectedMoney[0].transform.localPosition.x;
            collectedMoney[i].transform.DOLocalMove(Pos, 0.70f);
        }
    }

}
