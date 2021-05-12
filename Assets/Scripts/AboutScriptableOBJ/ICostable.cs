using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICostable
{
    int PayCost(int _costNum);

    bool CheckCost(int _costNum);
}
