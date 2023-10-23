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
    public class SurtrBase : TerrarianBase
    {
	public override string Name => "Surtr";
	public override string Description => "Rhodes Island Guard Operator Surtr, a person difficult to approach. Hopefully she will make an exception for the Doctor.";
	public override int Age => 21;
	public override Genders Gender => Genders.Female;
    public override float AccuracyPercent => 0.85f;
    public override float MaxRunSpeed => 4.6f;
    public override float RunAcceleration => 0.22f;
    public override float RunDeceleration => 0.37f;
    public override int JumpHeight => 15;
    public override float JumpSpeed => 5.45f;
    public override bool CanUseHeavyItem => true;
	public override int InitialMaxHealth => 133;
	public override int InitialMaxMana => 75;
	public override int HealthPerLifeCrystal => 20;
	public override int HealthPerLifeFruit => 10;        
    public override BehaviorBase DefaultFollowLeaderBehavior => (BehaviorBase)(object)new SurtrFollowLeaderBehavior();
    protected override CompanionDialogueContainer GetDialogueContainer => new Docter.SurtrDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 45f;
            companion.DefenseRate += 1.75f;
            companion.BlockRate += 25f;
            ((Player)companion).GetArmorPenetration<MeleeDamageClass>() += 28f;
            ((Player)companion).GetAttackSpeed<MeleeDamageClass>() += 1.35f;
            companion.BlockRate += 5f;
            ref StatModifier damage = ref ((Player)companion).GetDamage<MagicDamageClass>();
		    damage *= 1.45f;
            ref StatModifier damage1 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage1 *= 1.75f;
            ref StatModifier damage2 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage2 -= 25f;
            ref StatModifier damage3 = ref ((Player)companion).GetDamage<SummonDamageClass>();
		    damage3 -= 45f;
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
                new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.Surtrhat>(), 1),
                new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.SurtrJacket>(), 1),
                new InitialItemDefinition(ModContent.ItemType<Content.Items.Armor.Vanity.SurtrPants>(), 1),
                new InitialItemDefinition(188, 100)
            };
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
