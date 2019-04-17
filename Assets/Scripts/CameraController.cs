using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public bool shakeFlag;

    private bool cancelShake = false;               //是否取消震动

    private void Update()
    {
        if (shakeFlag)
        {
            StartCoroutine(ShakeCamera());
            shakeFlag = false;
        }
    }

    /*
     * 震动摄像机
     * shakeStrength ->震动幅度
     * rate -> 震动频率
     * shakeTime -> 震动时长
     */
    IEnumerator ShakeCamera(float shakeStrength = 0.2f, float rate = 14, float shakeTime = 0.4f)
    {
        float t = 0;    //计时器
        float speed = 1 / shakeTime;    //震动速度
        Vector3 orgPosition = transform.localPosition;  //摄像机震动前的位置
        Debug.Log("orgPosition.x: " + orgPosition.x);

        while (t < 1 && !cancelShake)
        {
            t += Time.deltaTime * speed;
            transform.position = orgPosition + new Vector3(Mathf.Sin(rate * t), Mathf.Cos(rate * t), 0) * Mathf.Lerp(shakeStrength, 0, t);
            yield return null;
        }
        cancelShake = false;
        transform.position = orgPosition;   //还原摄像机位置
    }
}
