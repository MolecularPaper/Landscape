using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarCTRL))]
public class CarAutoCTRL : MonoBehaviour
{
    [SerializeField] private CarPoint[] point;
    [SerializeField] private float steerTurnSpeed = 4f;

    [Header("Info")]
    [ShowOnly, SerializeField] private int pointIndex = 0;
    [ShowOnly, SerializeField] private bool indexCanUp = true;
    [ShowOnly, SerializeField] private float pointDistance;


    private CarCTRL carCTRL { get; set; }

    // Update is called once per frame
    private void Awake()
    {
        carCTRL = GetComponent<CarCTRL>();

        StartCoroutine(UpdateCarState());
    }

    private IEnumerator UpdateCarState()
    {
        while (pointIndex < point.Length) {
            UpdateDistance();
            if (pointDistance > 7f) MoveCar();
            else PointIndexUp();
            yield return null;
        }
        
        yield return StartCoroutine(carCTRL.StopCar());

        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(carCTRL.TrunOffLight());

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(carCTRL.TrunOffEngine());

        carCTRL.ExitTrigger();
    }

    private float LookAngle(Vector3 targetPos, Vector3 trPos)
    {
        Vector3 dir = targetPos - trPos;
        dir.y = 0f;

        Quaternion look = Quaternion.LookRotation(dir.normalized);
        Vector3 rot = transform.rotation.eulerAngles - look.eulerAngles;

        return rot.y;
    }

    private void MoveCar()
    {
        float angle = LookAngle(point[pointIndex].transform.position, transform.position);

        if(Mathf.Abs(angle) > 180) {
            angle = -(angle - 180);
        }

        indexCanUp = true;
        carCTRL.SteerAngle = Mathf.MoveTowards(carCTRL.SteerAngle, angle * carCTRL.SteerRatio, steerTurnSpeed);
        carCTRL.MortorTorque = point[pointIndex].torque;
    }

    private void PointIndexUp()
    {
        if (indexCanUp) {
            pointIndex++;
            indexCanUp = false;
        }
    }

    private void UpdateDistance()
    {
        Vector3 trPos = transform.position;
        trPos.y = 0;

        Vector3 targetPos = point[pointIndex].transform.position;
        targetPos.y = 0;

        pointDistance = Vector3.Distance(trPos, targetPos);
    }
}
