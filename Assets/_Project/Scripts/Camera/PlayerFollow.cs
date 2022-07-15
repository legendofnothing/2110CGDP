using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerPos;
    private bool _outOfCam;
    private Vector3 _playerCamPos;
    public float camSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _playerCamPos.z = this.transform.position.z;
        if (_outOfCam)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _playerCamPos, camSpeed);
        }
        //cam.transform.position = Vector3.MoveTowards(cam.transform.position, playerPos.position, 1);
        if(playerPos.position.x < this.transform.position.x - 3 || playerPos.position.x > this.transform.position.x + 3)
        {
            _playerCamPos.y = this.transform.position.y;
            _playerCamPos.x = playerPos.position.x;
            _outOfCam = true;
        }
        else if (playerPos.position.y > this.transform.position.y + 1.5f || playerPos.position.y < this.transform.position.y - 1.5f)
        {
            _playerCamPos.x = this.transform.position.x;
            _playerCamPos.y = playerPos.position.y;
            _outOfCam = true;
        }
        else 
        {
            _outOfCam = false;
        }
    }
}
