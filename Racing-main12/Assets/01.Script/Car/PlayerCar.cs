using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;


public class PlayerCar : BaseCar
{
    private float Maxtime = 6f;
    private float CurrenTime = 0f;
    public override void Movement()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        Break = Input.GetKey(KeyCode.Space) ? BreakForce : 0;
        base.Movement();
    }

    public IEnumerator Booster(int Speed)
    {
        float CurrentMotor = motor;
        motor = motor * Speed;
        yield return new WaitForSeconds(3f);
        motor = CurrentMotor;
        StopBoosterCoroutine();
    }

    public void StopBoosterCoroutine()
    {
        // 현재 진행 중인 Booster 코루틴을 중지
        StopCoroutine("Booster");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.velocity = rb.velocity * 1.5f;
        }
    }
}