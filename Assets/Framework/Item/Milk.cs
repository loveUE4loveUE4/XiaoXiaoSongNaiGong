using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Milk : MonoBehaviour
{
    public bool isStatic = true;
    public Vector3 targetPos;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isStatic)
        {
            transform.DORotate(new Vector3(0, 180, 0), 3f).SetEase(Ease.Linear).SetLoops(-1);
        }
        else
        {
            transform.DOMove(targetPos, 0.5f).SetEase(Ease.Linear);
            transform.DOScale(new Vector3(0.005f, 0.005f, 0.005f), 0.5f).SetEase(Ease.Linear);
            transform.DORotate(new Vector3(0, 180, 0), 2f).SetEase(Ease.Linear).SetLoops(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 ScreenToWorld()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosOnScreen = UIManager.GetInstance().panelRecord.GetChild(0).position;
        mousePosOnScreen.z = screenPos.z;
        return Camera.main.ScreenToWorldPoint(mousePosOnScreen);
    }
    public void SongNai() {
        transform.DOScale(new Vector3(0.006f, 0.006f, 0.006f), 0.3f).SetEase(Ease.Linear).OnComplete(delegate ()
        {
            transform.DOMove(ScreenToWorld(), 0.5f).SetEase(Ease.Linear);
            transform.DORotate(transform.eulerAngles + new Vector3(0, 360, 0), 0.5f).SetEase(Ease.Linear);
            transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(delegate () {
                UIManager.GetInstance().AddDishuNum();
                UIManager.GetInstance().canClickLeftBtn = true;
                UIManager.GetInstance().canClickRightBtn = true;
                Destroy(this.gameObject);
            });
        });
       
    }
}
