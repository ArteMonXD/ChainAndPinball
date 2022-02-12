using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LauncherMechanism : MonoBehaviour
{
    private SpringJoint launcherSJ;
    private Rigidbody thisRigidbody;
    [SerializeField] private float waitToleranceValue = 1f;
    [SerializeField] private float startToleranceValue = 0.001f;
    [SerializeField] private Vector3 waitPosition;
    [SerializeField] private int timeDelay;
    [SerializeField] private float speedRecovery;
    [SerializeField] private bool start;
    [SerializeField] private bool ready = true;
    public bool ReadyState
    {
        get { return ready; }
    }
    [SerializeField] private Transform projectilePositionStart;
    public Vector3 ProjectilePositionStart
    {
        get { return projectilePositionStart.position; }
    }
    [SerializeField] private GameObject closeLauncherWall;
    public GameObject CloseLauncherWall
    {
        get { return closeLauncherWall; }
    }
    void Start()
    {
        launcherSJ = GetComponent<SpringJoint>();
        thisRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        RecoveryState();
    }
    [ContextMenu("Start Projectile")]
    public void StartProjectile()
    {
        if (ready)
        {
            
            start = true;
            ready = false;
            InterfaceSystem.Instance.ButtonInteractableControll(Constance.ButtonsNames.STARTBUTTONNAME, false);
            launcherSJ.tolerance = startToleranceValue;
            GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
            Invoke("Prerecovery", timeDelay);
        }
    }

    private void RecoveryState()
    {
        if (!start && !ready)
        {
            if (!thisRigidbody.isKinematic)
                thisRigidbody.isKinematic = true;
            if(transform.localPosition != waitPosition)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, waitPosition, speedRecovery * Time.deltaTime);
            }
            else
            {
                ready = true;
                thisRigidbody.isKinematic = false;
                InterfaceSystem.Instance.ButtonInteractableControll(Constance.ButtonsNames.STARTBUTTONNAME, true);
            }
        }
    }

    private void Prerecovery()
    {
        launcherSJ.tolerance = waitToleranceValue;
        start = false;
        thisRigidbody.isKinematic = true;
        /*
        if (!closeLauncherWall.activeSelf)
        {
            closeLauncherWall.SetActive(true);
        }
        */
    }
}
