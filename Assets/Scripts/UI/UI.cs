using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private Player player;

    private CombatManager combatManager;

    private Label labelHealth;
    private Label labelPoint;
    private Label labelWave;
    private Label LabelEnemyLeft;
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Label labelHealth = root.Q<Label>("LabelHealth");
        Label labelPoint = root.Q<Label>("LabelPoint");
        Label labelWave = root.Q<Label>("LabelWave");
        Label LabelEnemyLeft = root.Q<Label>("LabelEnemyLeft");
        Player player = GameObject.Find("/player").GetComponent<Player>();
        CombatManager combatManager = GameObject.Find("/CombatManager").GetComponent<CombatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        labelHealth.text = "Health: " + player.healthComponent.GetHealth();
        labelWave.text = "Wave: " + combatManager.GetWave();
        LabelEnemyLeft.text = "Enemy Left: " + combatManager.GetEnemyLeft();
        labelPoint.text = "Point: " + combatManager.GetEnemyKilled();
    }
}
