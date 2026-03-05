using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NamesList : MonoBehaviour
{
    [SerializeField] private List<FirstNameSO> firstNames;
    [SerializeField] private List<LastNameSO> lastNames;
    
    public LastNameSO GetRandomLastName(int seed)
    {
        Random.InitState(seed);
        return lastNames[Random.Range(0, lastNames.Count)];
    }

    public List<LastNameSO> GetRandomLastNames(int seed, int count)
    {
        Random.InitState(seed);
        
        List<LastNameSO> result = new List<LastNameSO>();
        for (int i = 0; i < count; i++)
        {
            LastNameSO newName = lastNames[Random.Range(0, lastNames.Count)];
            if (result.Any(x => x.name == newName.name))
            {
                i--;
                continue;
            }
            else
            {
                result.Add(newName);
            }
        }

        return result;
    }

    public FirstNameSO GetRandomFirstName(int seed, Gender gender)
    {
        List<FirstNameSO> filteredList = firstNames.Where(x => x.Gender == gender).ToList();
        
        Random.InitState(seed);
        return filteredList[Random.Range(0, filteredList.Count)];
    }
}
