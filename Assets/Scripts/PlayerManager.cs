using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static private PlayerManager _instance;
    static public PlayerManager instance { get { return _instance; } }

    [SerializeField] GameObject UpgradePanel;
    [SerializeField] Player _player;
    [SerializeField] Drone _drone;

    public static void EnableUpgrade()
    {
        _instance.UpgradePanel.SetActive(true);
    }

    public void PlayerUpgrade()
    {
        _player.upgrade += 0.1f;
        UpgradePanel.SetActive(false);
    }

    public void DroneUpgrade()
    {
        _drone.upgrade += 0.1f;
        UpgradePanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
