using Microsoft.Xna.Framework;
using terraguardians;
using Terraria.ID;
using ArknightsMod;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace DocterMain.Companions
{
    //Extending TerraGuardianBase will allow you to create custom companion ready companions.
    //Extending TerrarianBase, allows instead to create Terrarian companions. Check TerraGuardians 1.4 source for example.
    //Extend CompanionCase if you want to try something different for companions.
    public class JessicatheLiberatedBase : TerrarianBase
    {
	public override string Name => "Jessica the Liberated";
	public override string Description => "Jessica, a Defender Operator, now serving as the Sheriff of a small barrenlands settlement. She came back from the burning battlefield to take a rest by a campfire.";
	public override int Age => 21;
	public override Genders Gender => Genders.Female;
    public override float AccuracyPercent => 0.85f;
    public override float MaxRunSpeed => 4.6f;
    public override float RunAcceleration => 0.22f;
    public override float RunDeceleration => 0.37f;
    public override int JumpHeight => 15;
    public override float JumpSpeed => 5.45f;
    public override bool CanUseHeavyItem => true;
	public override int InitialMaxHealth => 100;
	public override int InitialMaxMana => 250;
	public override int HealthPerLifeCrystal => 20;
    public override BehaviorBase DefaultFollowLeaderBehavior => (BehaviorBase)(object)new NengFollowLeaderBehavior();
	public override int HealthPerLifeFruit => 10;        
    protected override CompanionDialogueContainer GetDialogueContainer => new Docter.NengDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 15f;
            companion.DefenseRate += 45f;
            companion.BlockRate += 45f;
            ((Player)companion).GetArmorPenetration<RangedDamageClass>() += 26f;
            ((Player)companion).GetAttackSpeed<RangedDamageClass>() += 1.25f;
            ref StatModifier damage = ref ((Player)companion).GetDamage<MagicDamageClass>();
		    damage -= 25f;
            ref StatModifier damage1 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage1 *= 1.55f;
            ref StatModifier damage2 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage2 *= 1.5f;
            ref StatModifier damage3 = ref ((Player)companion).GetDamage<SummonDamageClass>();
		    damage3 -= 25f;
            if (companion.FriendshipLevel >= 2) {
                companion.MaxHealth += 50;
            }
            if (companion.FriendshipLevel >= 4) {
                companion.MaxHealth += 50;
            }
            if (companion.FriendshipLevel >= 6) {
                companion.MaxHealth += 50;
            }
            if (EliteSystem.JessicatheLiberatedEliteA)
		    {
            companion.DodgeRate += 5f;
			companion.MaxHealth += 350;
            companion.BlockRate += 15f;
			((Player)companion).lifeRegen = ((Player)companion).lifeRegen + 15;
            ref StatModifier damage6 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage6 *= 1.75f;
            ref StatModifier damage7 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage7 *= 2.5f;
		    }
            if (EliteSystem.JessicatheLiberatedEliteB)
		    {
            companion.DodgeRate += 5f;
            companion.BlockRate += 15f;
            ((Player)companion).GetCritChance<RangedDamageClass>() += 20f;
            ((Player)companion).GetArmorPenetration<RangedDamageClass>() += 22f;
			companion.MaxHealth += 550;
			((Player)companion).lifeRegen = ((Player)companion).lifeRegen + 25;
            ref StatModifier damage4 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage4 *= 2.25f;
            ref StatModifier damage5 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage5 *= 2.95f;
		    }
        }
        protected override TerrarianCompanionInfo SetTerrarianCompanionInfo
        {
            get
            {
                return new TerrarianCompanionInfo()
                {
                    HairStyle = 51,
                    SkinVariant = 6,
                    HairColor = new Color(255, 255, 255),
                    EyeColor = new Color(39, 147, 30),
                    SkinColor = new Color(255, 223, 214),
                    ShirtColor = new Color(255, 255, 255),
                    UndershirtColor = new Color(255, 255, 255),
                    PantsColor = new Color(66, 66, 66),
                    ShoesColor = new Color(38, 240, 255)
                };
            }
        }

        
        public override void InitialInventory(out InitialItemDefinition[] InitialInventoryItems, ref InitialItemDefinition[] InitialEquipments)
	    {
		if (ModLoader.TryGetMod("ArknightsMod", out Mod ArknightsMod))
        {
            InitialInventoryItems = new InitialItemDefinition[]
            {
                new InitialItemDefinition(ModContent.ItemType<Content.Items.Weapons.STI2011>(), 1),
                new InitialItemDefinition(1302, 9999),
                new InitialItemDefinition(1987, 1),
                new InitialItemDefinition(188, 100),
            };
            InitialEquipments[10] = new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.Jessicahat>());
            InitialEquipments[11] = new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.JessicaJacket>());
            InitialEquipments[12] = new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.JessicaPants>());
        }
		else
		{
			InitialInventoryItems = (InitialItemDefinition[])(object)new InitialItemDefinition[7]
			{
				new InitialItemDefinition(1306, 1),
				new InitialItemDefinition(533, 1),
				new InitialItemDefinition(1302, 9999),
				new InitialItemDefinition(188, 100),
                new InitialItemDefinition(188, 100),
                new InitialItemDefinition(188, 100),
                new InitialItemDefinition(188, 100),
			};
		}
	}
}
}
