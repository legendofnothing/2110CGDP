using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerFollow : MonoBehaviour
{
    //private float _playerScale;
    //public CinemachineVirtualCamera thisCam;
    //private float _shiftTime;
    //private float _screenX;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    thisCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.5f;
    //    _screenX = 0.5f;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    _playerScale = GameObject.Find("Player").GetComponent<Transform>().rotation.y;
    //    thisCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = _screenX;

    //    if (_playerScale == 0f)
    //    {
    //        thisCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.4f;
    //    }
    //    else if (_playerScale == -1f)
    //    {
    //        thisCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.6f;
    //    }
    //}

    //IEnumerator ShiftCam(float dur, float newScreenX)
    //{
    //    //float elapsed = 0.0f;
    //    //while (elapsed < dur)
    //    //{
    //    //    _screenX = Mathf.Lerp(_screenX, newScreenX, elapsed / dur);
    //    //    elapsed += Time.deltaTime;
    //    //    yield return null;
    //    //}
    //    //_screenX = newScreenX;
    //    yield return new WaitForSeconds(dur);
    //    _screenX = newScreenX;
    //}
}
