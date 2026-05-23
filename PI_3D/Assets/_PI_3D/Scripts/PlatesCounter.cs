using UnityEngine;

public class PlatesCounter : BaseCounter
{
    private float spawnPlatetimer;
    private float spawnPlateTimeMax = 4f;

    private void Update()
    {
        spawnPlatetimer += Time.deltaTime;
        if (spawnPlatetimer > spawnPlateTimeMax)
        {

        }
    }
}
