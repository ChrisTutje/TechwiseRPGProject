using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, VICTORY, DEFEAT, FLEE } //list of Battle Phases

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    public AudioSource battleTheme;
    public AudioSource victoryFanfare;
    public AudioSource gameoverTheme;

    public AudioSource attackSfx;
    public AudioSource healSfx;
    public AudioSource menuNegative;
    public AudioSource blockSFX;
   
    void Start()
    {
        state = BattleState.START;
        battleTheme.Play();
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() { //co-routine for the START phase
       GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
       playerUnit = playerGO.GetComponent<Unit>();

       GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
       enemyUnit = enemyGO.GetComponent<Unit>();

      dialogueText.text = "A hostile " + enemyUnit.unitName + " challenges you!";

      yield return new WaitForSeconds(2f); // the setUp phase waits for 2 seconds 

      state = BattleState.PLAYERTURN;
      PlayerTurn();

      playerHUD.setHUD(playerUnit);
      enemyHUD.setHUD(enemyUnit);
    }

    void PlayerTurn() { //function for the PlayerTurn phase
    dialogueText.text = "Round " + roundCounter +  ": \n How will " +  playerUnit.unitName + " respond?" ;
    roundCounter += 1; //used to increment the round counter
    }

        IEnumerator PlayerAttack() { //Logic for the fight action
       int damageToEnemy = playerUnit.attack - enemyUnit.defence;
       int actualDamage = enemyUnit.TakeDamage(damageToEnemy);
       int staminaCost = 1;
            if (playerUnit.equippedArmor != null)
            {
                staminaCost *= playerUnit.equippedArmor.armorWeight;
            }

          if (playerUnit.IsExhausted())
        {
            menuNegative.Play();
            dialogueText.text = playerUnit.unitName + " is exhausted and cannot attack!";
            yield return new WaitForSeconds(2f);
           
        } else {
            attackSfx.Play();

            enemyHUD.SetHP(enemyUnit.currentHp);
            dialogueText.text = "POW! \n" + enemyUnit.unitName + " takes " + actualDamage + " damage!" ;

            yield return new WaitForSeconds(2f);

        if(enemyUnit.IsKo()) { 
            state = BattleState.VICTORY;
            EndBattle();
        } else {

            playerUnit.DrainStamina(staminaCost);

            playerHUD.SetStamina(playerUnit.currentStamina);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        }

    }

       IEnumerator PlayerBlock() { //blocking action, double's unit defence, restore some stamina, and revert defence when done
       int originalDefence = playerUnit.defence; 

       blockSFX.Play();

        playerUnit.Block();
        playerUnit.defence *= 2; 
        playerUnit.RestoreStamina(2); 
        playerHUD.SetStamina(playerUnit.currentStamina);

        dialogueText.text = playerUnit.unitName + " defends!";

        yield return new WaitForSeconds(2f);


        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

        playerUnit.defence = originalDefence; 
    }

        IEnumerator PlayerRest() {
        int staminaRecovery = 4;
        playerUnit.RestoreStamina(staminaRecovery);
        playerHUD.SetStamina(playerUnit.currentStamina);

        dialogueText.text = playerUnit.unitName + " recovers " + staminaRecovery + " stamina.";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerCharge() { //temporarily doubles unit's attack and halves their defence at high stamina cost 
       int originalAttack = playerUnit.attack;
       int originalDefence = playerUnit.defence;
       int staminaCost = 4;
            if (playerUnit.equippedArmor != null)
            {
                staminaCost *= playerUnit.equippedArmor.armorWeight;
            }

          if (playerUnit.IsExhausted() || playerUnit.currentStamina < staminaCost)
        {
            menuNegative.Play();
            dialogueText.text = playerUnit.unitName + " is exhausted and cannot attack!";
            yield return new WaitForSeconds(2f);
        
        } else {
            attackSfx.Play();
            playerUnit.attack *= 2;
            playerUnit.defence /= 2;
            int damageToEnemy = playerUnit.attack - enemyUnit.defence;
            int actualDamage = enemyUnit.TakeDamage(damageToEnemy);

            enemyHUD.SetHP(enemyUnit.currentHp);
            dialogueText.text = "KAPOW!!! \n" + enemyUnit.unitName + " takes " + actualDamage + " damage!" ;

            yield return new WaitForSeconds(2f);

        if(enemyUnit.IsKo()) { 
            state = BattleState.VICTORY;
            EndBattle();
        } else {
 
            playerUnit.DrainStamina(staminaCost);
            playerHUD.SetStamina(playerUnit.currentStamina);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

            playerUnit.attack = originalAttack;
            playerUnit.defence = originalDefence;
        }

        }
    }

       IEnumerator PlayerHeavyAttack() { //Heavy attack action. higher stamina cost than fight, and boosts PlayerAttack by 1.5 rounded down
       int originalAttack = playerUnit.attack;
       int originalDefence = playerUnit.defence;
       int staminaCost = 2;
            if (playerUnit.equippedArmor != null)
            {
                staminaCost *= playerUnit.equippedArmor.armorWeight;
            }

          if (playerUnit.IsExhausted() || playerUnit.currentStamina < staminaCost)
        {
            menuNegative.Play();
            dialogueText.text = playerUnit.unitName + " is exhausted and cannot attack!";
            yield return new WaitForSeconds(2f);
        } else {
            attackSfx.Play();
            if (playerUnit.attack % 2 == 0) {
                 playerUnit.attack += playerUnit.attack / 2; 
           } else {
                playerUnit.attack += (playerUnit.attack + 1) / 2;
            }
            int damageToEnemy = playerUnit.attack - enemyUnit.defence;
            int actualDamage = enemyUnit.TakeDamage(damageToEnemy);

            enemyHUD.SetHP(enemyUnit.currentHp);
            dialogueText.text = "OOF! \n" + enemyUnit.unitName + " takes " + actualDamage + " damage!" ;

            yield return new WaitForSeconds(2f);

        if(enemyUnit.IsKo()) { 
            state = BattleState.VICTORY;
            EndBattle();
        } else {
           
            playerUnit.DrainStamina(staminaCost);
            playerHUD.SetStamina(playerUnit.currentStamina);

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());

            playerUnit.attack = originalAttack;
        }

        }
    }

    IEnumerator PlayerCure() { //healing action
    int mpCost = 8;
      if (playerUnit.currentMp >= mpCost){
        healSfx.Play();
        int hpRecovery = 8; //how much action heals by
        playerUnit.Heal(hpRecovery);
        playerUnit.DeductMP(8);
        playerHUD.SetMP(playerUnit.currentMp);

        playerHUD.SetHP(playerUnit.currentHp);
        dialogueText.text = playerUnit.unitName + " regained " + hpRecovery  + " hit points.";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
      } else {
        menuNegative.Play();
        dialogueText.text = "Not enough MP for Cure!";
      }
        
    }

    IEnumerator PlayerRevitalize() //healing action that also restores stamina
{
    int mpCost = 16;
    int staminaRestore = 4;
    int hpRecovery = 16;

    if (playerUnit.currentMp < mpCost)
    {
        menuNegative.Play();
        dialogueText.text = "Not enough MP for Revitalize!";
    }
    else
    {
        playerUnit.RestoreStamina(staminaRestore);
        playerUnit.DeductMP(mpCost);
        playerUnit.Heal(hpRecovery);

        playerHUD.SetStamina(playerUnit.currentStamina);
        playerHUD.SetMP(playerUnit.currentMp);
        playerHUD.SetHP(playerUnit.currentHp);

        dialogueText.text = playerUnit.unitName + " uses Revitalize!\nRestores " + hpRecovery + "HP and " + staminaRestore + " stamina!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
}

    IEnumerator PlayerFireBomb() //deals magic damage and drains enemy stamina
{
    int mpCost = 12;

    if (playerUnit.currentMp < mpCost)
    {
        menuNegative.Play();
        dialogueText.text = "Not enough MP for Fire Bomb!";
    }
    else
    {
        int damageToEnemy = 9;
        int actualDamage = enemyUnit.TakeDamage(damageToEnemy);

        playerUnit.DeductMP(mpCost);
        playerHUD.SetMP(playerUnit.currentMp);

        enemyUnit.DrainStamina(4);
        enemyHUD.SetStamina(enemyUnit.currentStamina);

        dialogueText.text = "FWOOSH! " + playerUnit.unitName + " casts Fire Bomb!\n" + enemyUnit.unitName + " takes " + actualDamage + " damage and loses 1 stamina!";

        yield return new WaitForSeconds(2f);

        enemyHUD.SetHP(enemyUnit.currentHp);

        if (enemyUnit.IsKo())
        {
            state = BattleState.VICTORY;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
} 

        IEnumerator PlayerGodlyStrike() { //deals heavy magic damage
        int mpCost = 24;

        if (playerUnit.currentMp >= mpCost) {
        healSfx.Play();
        int damageToEnemy = 21;
        int actualDamage = enemyUnit.TakeDamage(damageToEnemy);

        playerUnit.currentMp -= mpCost;
        playerHUD.SetMP(playerUnit.currentMp);

        dialogueText.text = "ZZAP! " + playerUnit.unitName + " casts Godly Strike! \n" + enemyUnit.unitName + " takes " + actualDamage + " damage!";

    yield return new WaitForSeconds(2f);

    enemyHUD.SetHP(enemyUnit.currentHp);

    if (enemyUnit.IsKo())
    {
        state = BattleState.VICTORY;
        EndBattle();
    }
    else
    {
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }
        } else {
        menuNegative.Play();
        dialogueText.text = "Not enough MP for Godly Strike!";
      }
        
        
    } 

   IEnumerator PlayerFlee() //flee action, uses a virtual D20 to calculate escape chance, more difficult with higher level enemies 
{
    dialogueText.text = playerUnit.unitName + " attempts to flee...";

    yield return new WaitForSeconds(1f);

   float escapeSuccess = randomEvents.d20();
   float escapeFail = enemyUnit.unitLevel;
    if (escapeSuccess >= escapeFail) // Escape rate
    {
        dialogueText.text = "Escape successful! " + playerUnit.name + " ran away!";
        state = BattleState.FLEE;
        EndBattle(); battleTheme.Stop();
        StartCoroutine(SwitchGame());
        
    }
    else
    {
        dialogueText.text = "Escape failed! You must stand and fight!";
        state = BattleState.ENEMYTURN; 
        StartCoroutine(EnemyTurn());
    }
}

IEnumerator EnemyTurn() { //enemy turn and A.I. The enemy will attack until they are exhausted, then they will rest
        int damageToPlayer =  enemyUnit.attack - playerUnit.defence;
        int actualDamage = playerUnit.TakeDamage(damageToPlayer);
        int staminaCost = 1;
            if (enemyUnit.equippedArmor != null)
            {
                staminaCost *= enemyUnit.equippedArmor.armorWeight;
            }

        if (enemyUnit.IsExhausted())
        {
            dialogueText.text =enemyUnit.unitName + " is exhausted and takes a rest!";
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            StartCoroutine(EnemyRest());
            yield break;
        } else {
        attackSfx.Play();
        dialogueText.text = enemyUnit.unitName + " attacks " + playerUnit.unitName + "! \n" + playerUnit.unitName + " takes " + actualDamage + " damage!";
        
        yield return new WaitForSeconds(1f);

        playerHUD.SetHP(playerUnit.currentHp);

        yield return new WaitForSeconds(1f);

        if(playerUnit.IsKo()) {
            state = BattleState.DEFEAT;
            EndBattle();
        } else {
            
            enemyUnit.DrainStamina(staminaCost);
            
            enemyHUD.SetStamina(enemyUnit.currentStamina);


            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

        }

        

    }

    IEnumerator EnemyRest() { //enemy rest action to restore stamina 
        int staminaRecovery = 4;
        enemyUnit.RestoreStamina(staminaRecovery);
        enemyHUD.SetStamina(enemyUnit.currentStamina);

        dialogueText.text = enemyUnit.unitName + " recovered " + staminaRecovery + " stamina!";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void EndBattle() { 
        if(state == BattleState.VICTORY) {
            battleTheme.Stop();
            victoryFanfare.Play(); //switch to the victory fanfare

            playerUnit.currentExp += enemyUnit.expDrop; //gain EXP 
            playerHUD.SetEXP(playerUnit.currentExp);
            dialogueText.text = "Conglaturations! You are winner!!! \n You gained " + enemyUnit.expDrop + " experience points!";

            StartCoroutine(SwitchGameVictory());
            

        } else if (state == BattleState.DEFEAT){
            battleTheme.Stop(); 
            dialogueText.text = "Get gud, skrub.";
            SceneManager.LoadScene("Game_Over");

        } 
   

    }

    IEnumerator SwitchGame() //transition from battle to the overworld
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainGame");
    }

   IEnumerator SwitchGameVictory() //transition from battle to either the overworld or ending credits
{
    

    string currentSceneName = SceneManager.GetActiveScene().name;

    if (currentSceneName == "FelipeBossBattle")
    {
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene("Credits");
    }
    else if (currentSceneName == "BattleScene")
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainGame");
    }
}

    public int roundCounter = 1;


    //**vvv Logic for Action Moves go here vvv **// 

    public void OnAttackButton(){ //logic for button presses
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());

    }

    public void OnCureButton()
{
    if (state != BattleState.PLAYERTURN)
        return;

    StartCoroutine(PlayerCure());
}

    public void OnBlockButton(){
       if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerBlock());
    }

    public void OnRestButton(){
       if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerRest());
    }

    public void OnFleeButton()
{
    if (state != BattleState.PLAYERTURN)
        return;

    StartCoroutine(PlayerFlee());
}

public void OnGodlyStrike()
{
    if (state != BattleState.PLAYERTURN)
        return;

    StartCoroutine(PlayerGodlyStrike());
}

public void OnChargeButton(){
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerCharge());

    }

public void OnHeavyAttack(){
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerHeavyAttack());

    }

    public void OnFireBomb(){
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerFireBomb());

    }

    public void OnRevitalize(){
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerRevitalize());

    }
    
}
