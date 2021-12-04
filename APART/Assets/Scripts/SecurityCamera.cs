using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float rotateSpeed = 60f;
    public float completeRotationArc = 90f;
    public float offsetAngle = 45f;

    public bool canSeePlayer = false;

    private float playerSpeedMovePenalty = 3f;

    private PlayerController player;

    [SerializeField]
    private Transform pivotPoint;

    float timer = 0f;

    private void Update()
    {
        if (!canSeePlayer)
        {
            timer += Time.deltaTime;
            pivotPoint.localEulerAngles = new Vector3(Mathf.PingPong(timer * rotateSpeed, completeRotationArc) - (offsetAngle - 90f), 90f, 90f);
        }
        else
        {
            //pivotPoint.LookAt(player.transform.position, transform.forward);
        }
    }

    public void FoundPlayer(PlayerController seenPlayer)
    {
        canSeePlayer = true;
        player = seenPlayer;
        seenPlayer.moveSpeed = playerSpeedMovePenalty;

        //fire event for guards to chase player maybe
    }

    public void LostPlayer(PlayerController lostPlayer)
    {
        canSeePlayer = false;
        lostPlayer.moveSpeed = lostPlayer.maxMoveSpeed;
    }

    //in order for the camera to continue rotating how it was, gotta use own timer instead of Time.time
    /*IEnumerator RotateCamera()
    {
        print("hy");
        timer += Time.deltaTime;
        
        

        yield return null;
    }*/
}
