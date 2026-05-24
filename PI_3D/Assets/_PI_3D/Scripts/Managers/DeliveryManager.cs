using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipesMax = 3;


    private void Awake()
    {
        Instance = this; 
        
        waitingRecipeSOList = new List<RecipeSO>();
    }
    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if(waitingRecipeSOList.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
                waitingRecipeSOList.Add(waitingRecipeSO);
            }

        }
    }

    public void DeliverRecipe(PlateLaundaryObject plateLaundaryObject)
    {
        List<LaundaryObjectSO> plateLaundaryObjectSOList = plateLaundaryObject.GetLaundaryObjectSOList();

        for (int i = 0; i < waitingRecipeSOList.Count; ++i)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.laundaryObjectSOList.Count == plateLaundaryObject.GetLaundaryObjectSOList().Count)
            {
                //Tiene los mismo "ingredientes"
                bool recipeMatches = true;
                foreach (LaundaryObjectSO recipeLaundaryObjectSO in waitingRecipeSO.laundaryObjectSOList)
                {

                    bool ingredientFound = false;

                    foreach (LaundaryObjectSO plateLaundaryObjectSO in plateLaundaryObjectSOList)
                    {
                       
                       if (plateLaundaryObjectSO == recipeLaundaryObjectSO)
                       {
                            //Ingredient matches
                            ingredientFound = true;
                            break;
                       }
                    }

                    if (!ingredientFound)
                    {
                        //The recipe ingredient weas not found on the basket
                        recipeMatches = false;

                    }

                }

                if (recipeMatches)
                {

                    //Player ddi the correct recipe
                    Debug.Log("Player delivered the correct recipe!");
                    waitingRecipeSOList.RemoveAt(i);
                    return;
                }

            }
        }

        //No matches found
        //Player no deliver correctly
        Debug.Log("Player did not deliver the recipe correctly");
    }


}
