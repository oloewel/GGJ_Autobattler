using UnityEngine;

class Maske : MonoBehaviour // Base class for the masks
{
    [SerializeField] private int lp; //LP will be genereated in Unity
    [SerializeField] private int sps; //SPS will be generated in Unity
    [SerializeField] private int speed; //Speed will be generated in Unity

    void Attack()
    {
      //function activates when gamecontroller function calls for it
      //select mask to target ? should it be included in the paranthesis?
      //calls for attack animation, attack animation plays
      Hit();//after animation is done, calls for defendermask.hit function to run
      //ends attack function  
    }
    void Hit()
    {
        //function activates when attack function calls for it ?
        //calls for hit animation, hit animation plays
        //to calculate, takes the stat of the mask being attacked (defendermask) and the sts of the attacking mask (attackermask)
        lp -= sps;//calculation -> defendermask.lp -= attackermask.sts
        if (lp <= 0) {Sterben();} //runs a check to see if defendermask.lp <= 0; if it returns true, run Sterben function
        //ends hit function
    }
    void Sterben()
    {
        //function activates when hit function calls for it
        this.enabled = false;//mask presence and object targetting is removed, so that existing masks cannot target the mask that is dead
        //this.SetTrigger("Dead");//calls of death animation, death animation plays
        Destroy(this, 3f);//mask graphics are removed
        //ends sterben function
    }

}
