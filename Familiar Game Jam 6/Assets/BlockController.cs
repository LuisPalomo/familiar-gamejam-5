using System;
using UnityEngine;
using System.Collections;

public enum BlockContents { Nothing, Coin, Egg, Star };

public class BlockController : MonoBehaviour
{
    public BlockContents contents = BlockContents.Coin;

    public GameObject coinPrefab;
    public GameObject eggPrefab;
    public GameObject starPrefab;
    public GameObject[] electricArcList;


    public SpriteRenderer spriteRenderer;
    public Sprite usedSprite;

    public float bumpAnimationAmount = 0.05f;
    public AnimationCurve bumpAnimationCurve = new AnimationCurve();

    public bool used = false;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!this.used)
        {
            if (Vector2.Dot(coll.contacts[0].normal, Vector2.up) > 0.75f)
            {
                this.used = true;
                this.spriteRenderer.sprite = this.usedSprite;
                this.SpawnObject();
                this.StartCoroutine(this.MakeBump());
                if (electricArcList!=null)
                {
                    foreach (var electricArc in electricArcList)
                    {
                        electricArc.GetComponent<ActivateTraps>().actTraps=true;
                    }
                }
            }
        }
    }

    private void SpawnObject()
    {
        GameObject createdObject = null;
        switch (this.contents)
        {
            case BlockContents.Coin:
                createdObject = GameObject.Instantiate<GameObject>(this.coinPrefab);
                break;
            case BlockContents.Egg:
                createdObject = GameObject.Instantiate<GameObject>(this.eggPrefab);
                break;
        }
        
        if (createdObject != null)
        {
            createdObject.transform.position = this.transform.position + (Vector3.up * 0.25f);
            createdObject.transform.SetParent(this.transform.parent);
        }
                
    }

    // Update is called once per frame
    private IEnumerator MakeBump()
    {
        Vector3 originalPosition = this.transform.localPosition;
        Vector3 targetPosition = originalPosition + (Vector3.up * this.bumpAnimationAmount);

        float normalizedTime = 0.0f, inverseTotalTime = 1.0f / 0.25f;
        while (normalizedTime < 1.0f)
        {
            this.transform.localPosition = Vector3.Lerp(originalPosition, targetPosition,
                                                   this.bumpAnimationCurve.Evaluate(normalizedTime));

            normalizedTime += Time.deltaTime * inverseTotalTime;
            yield return null;
        }

        this.transform.localPosition = originalPosition;
    }

}