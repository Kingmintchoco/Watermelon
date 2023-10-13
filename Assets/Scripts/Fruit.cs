using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public FruitState state {get; private set;}

    public void SetState(FruitState state){
        this.state = state;
    }
}
