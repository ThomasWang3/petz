using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Pet currPet;
    public List<Pet> currPets;
    public int petIndex;
    public int petIndexMax;
    public Human currHuman;
    public List<Human> currHumans;
    public int humanIndex;
    public int humanIndexMax;
    //private Pet currPet;
    //private Pet[] currPets;
    //private int petIndex;
    //private int petIndexMax;
    //private Human currHuman;
    //private Human[] currHumans;
    //private int humanIndex;
    //private int humanIndexMax;
    private string nextKey = "d";
    private string prevKey = "a";
    //private string dog = "dog";
    //private string cat = "cat";
    //private string fish = "fish";
    //private string snake = "snake";
    //private string bird = "bird";


    // Start is called before the first frame update
    void Start()
    {
        //need to fill pets array and humans array with all pets and humans in current fight
        petIndexMax = currPets.Count;
        humanIndexMax = currHumans.Count;
        currPet = currPets[petIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(prevKey)) {
            //Debug.Log("A key pressed");
            previous();
        }
        if (Input.GetKeyDown(nextKey)) {
            //Debug.Log("D key pressed");
            next();
        }

    }

    //goes to next pet if nextKey is pressed
    void next()
    {
        //Debug.Log("next function");
        if (petIndex < petIndexMax)
        {
            petIndex++;
            currPet = currPets[petIndex];
        }
        else
        {
            //do nothing
        }
    }

    //goes to previous pet if prevKey is pressed
    void previous()
    {
        //Debug.Log("previous function");
        if (petIndex > 0) {
            petIndex--;
            currPet = currPets[petIndex];
        }
        else
        {
            //do nothing
        }
    }

    //attacks and accommodates for type matchups 
    void attack()
    {
        // tentatively (both attack at the same time), player first
        // maybe implement animation between these in order to facilitate "turn order"
        currPet.AttackEnemy(currHuman);
        currHuman.AttackEnemy(currPet);
    }
}
