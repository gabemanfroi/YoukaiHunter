using UnityEngine;

namespace Player
{
    public class PlayerXp : MonoBehaviour
    {
        public int level = 1;
        public int xp = 0;
        public int xpToNextLevel = 20;
        public UpgradeUI upgradeUI;
    
        public void GainXp(int amount)
        {
            xp += amount;
            if (xp >= xpToNextLevel)
            {
                LevelUp();
            }
        }

        void LevelUp()
        {
            level++;
            xp -= xpToNextLevel;
            xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.5f); // Aumenta o requisito para o próximo nível
        
            upgradeUI.ShowUpgradeChoices();
        }
    }
}

