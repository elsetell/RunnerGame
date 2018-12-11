using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowTo : MonoBehaviour {
    public Transform player;
    public Vector3 offset;

#if UNITY_ANDROID
    private void Start()
    {
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
        Input.gyro.enabled = true;

        Transform skyObj = transform.GetChild(0);
        skyObj.SetParent(null);
        skyObj.gameObject.AddComponent<ObjectFollowTo>();
        ObjectFollowTo sky = skyObj.GetComponent<ObjectFollowTo>();
        sky.player = player;
        sky.offset.z = -320;
    }
#endif
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }

}
