using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private Pet currPet;
    private Pet[] currPets;
    private int petIndex;
    private int petIndexMax;
    private Human currHuman;
    private Human[] currHumans;
    private int humanIndex;
    private int humanIndexMax;
    private string nextKey = "d";
    private string prevKey = "a";
    private string dog = "dog";
    private string cat = "cat";
    private string fish = "fish";
    private string snake = "snake";
    private string bird = "bird";


    // Start is called before the first frame update
    void Start()
    {
        //need to fill pets array and humans array with all pets and humans in current fight
        petIndexMax = currPets.Length;
        humanIndexMax = currHumans.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //goes to next pet if nextKey is pressed
    void next()
    {
        if (Input.GetKeyDown(nextKey))
        {
            if (petIndex != petIndexMax)
            {
                petIndex++;
                currPet = currPets[petIndex];
            }
            else
            {
                //do nothing
            }
        }
    }

    //goes to previous pet if prevKey is pressed
    void previous()
    {
        if (Input.GetKeyDown(prevKey))
        {
            if (petIndex != 0)
            {
                petIndex--;
                currPet = currPets[petIndex];
            }
            else
            {
                //do nothing
            }
        }
    }

    //attacks and accommodates for type matchups 
    void attack()
    {
        //if dog type pet attacks cat type human do double damage, if attacks snake type human take double damage, otherwise both take normal damage
        if (currPet.GetCharType() == dog)
        {
            if (currHuman.GetCharType() == cat)
            {
                currHuman.DoDamage(currPet.GetAttack()*2);
            }
            else if (currHuman.GetCharType() == snake)
            {
                currPet.DoDamage(currHuman.GetAttack()*2);
            }
            else
            {
                currHuman.DoDamage(currPet.GetAttack());
                currPet.DoDamage(currHuman.GetAttack());
            }
        }
        else if (currPet.GetCharType() == cat)
        {
            if (currHuman.GetCharType() == bird)
            {
                currHuman.DoDamage(currPet.GetAttack() * 2);
            }
            else if (currHuman.GetCharType() == dog)
            {
                currPet.DoDamage(currHuman.GetAttack() * 2);
            }
            else
            {
                currHuman.DoDamage(currPet.GetAttack());
                currPet.DoDamage(currHuman.GetAttack());
            }
        }
        else if (currPet.GetCharType() == bird)
        {
            if (currHuman.GetCharType() == fish)
            {
                currHuman.DoDamage(currPet.GetAttack() * 2);
            }
            else if (currHuman.GetCharType() == cat)
            {
                currPet.DoDamage(currHuman.GetAttack() * 2);
            }
            else
            {
                currHuman.DoDamage(currPet.GetAttack());
                currPet.DoDamage(currHuman.GetAttack());
            }
        }
        else if (currPet.GetCharType() == fish)
        {
            if (currHuman.GetCharType() == snake)
            {
                currHuman.DoDamage(currPet.GetAttack() * 2);
            }
            else if (currHuman.GetCharType() == bird)
            {
                currPet.DoDamage(currHuman.GetAttack() * 2);
            }
            else
            {
                currHuman.DoDamage(currPet.GetAttack());
                currPet.DoDamage(currHuman.GetAttack());
            }
        }
        else if (currPet.GetCharType() == snake)
        {
            if (currHuman.GetCharType() == dog)
            {
                currHuman.DoDamage(currPet.GetAttack() * 2);
            }
            else if (currHuman.GetCharType() == fish)
            {
                currPet.DoDamage(currHuman.GetAttack() * 2);
            }
            else
            {
                currHuman.DoDamage(currPet.GetAttack());
                currPet.DoDamage(currHuman.GetAttack());
            }
        }
    }
}
