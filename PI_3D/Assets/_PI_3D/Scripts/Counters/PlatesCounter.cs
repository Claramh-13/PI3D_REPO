using System;
using UnityEngine;
public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private LaundaryObjectSO plateLaundaryObjectSO;
    private float spawnPlatetimer;
    private float spawnPlateTimeMax = 4f;
    private int platesSpawnedAmount;
    private int platesSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlatetimer += Time.deltaTime;
        if (spawnPlatetimer > spawnPlateTimeMax)
        {
            spawnPlatetimer = 0f;
            if (platesSpawnedAmount < platesSpawnedAmountMax)
            {
                platesSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(ILaundaryObjectParent laundaryObjectParent)
    {
        if (!laundaryObjectParent.HasLaundaryObject())
        {
            if (platesSpawnedAmount > 0)
            {
                platesSpawnedAmount--;
                LaundaryObject.SpawnLaundaryObject(plateLaundaryObjectSO, laundaryObjectParent);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

