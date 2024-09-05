using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ignore this, it allows for us to call for damage across multiple different scripts. basically, it defines what damage is and allows said damage to be called in different scripts.
//don't ask me how this happens, from my perspective its coding black magic
public interface DamageScript
{
    public void Damage(float damage);
}