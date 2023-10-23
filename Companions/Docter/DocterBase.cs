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
    public class DocterBase : TerrarianBase
    {
	public override string Name => "Doctor";
	public override string Description => "You can't recall anything.From the beginning.(Why does it look like Dante? I don't know.)";
	public override int Age => 21;
	public override Genders Gender => Genders.Male;
	public override float AccuracyPercent => 0.87f;
	public override int InitialMaxHealth => 100;
	public override int InitialMaxMana => 250;
	public override int HealthPerLifeCrystal => 20;
	public override int HealthPerLifeFruit => 10;        
    protected override CompanionDialogueContainer GetDialogueContainer => new Docter.DocterDialogues(); //I have split the companion dialogues to another file. Here, you initialize the object containing companion dialogues.
        public override void UpdateAttributes(Companion companion) //This updates whenever the companion status are reset. If you want to change their status, or give them other benefits, here is the place.
        {
            companion.DodgeRate += 45f;
            companion.GetCritChance<MeleeDamageClass>() += 15;
            companion.DefenseRate += 0.35f;
            ((Player)companion).GetAttackSpeed<MagicDamageClass>() += 1.55f;
            ((Player)companion).lifeSteal = ((Player)companion).lifeSteal + 0.25f;
            ((Player)companion).lifeRegen = ((Player)companion).lifeRegen + 10;
            ref StatModifier damage = ref ((Player)companion).GetDamage<MagicDamageClass>();
		    damage *= 2f;
            ref StatModifier damage1 = ref ((Player)companion).GetDamage<MeleeDamageClass>();
		    damage1 *= 2f;
            ref StatModifier damage2 = ref ((Player)companion).GetDamage<RangedDamageClass>();
		    damage2 *= 2f;
            ref StatModifier damage3 = ref ((Player)companion).GetDamage<SummonDamageClass>();
		    damage3 *= 2f;
        }
        protected override TerrarianCompanionInfo SetTerrarianCompanionInfo
        {
            get
            {
                return new TerrarianCompanionInfo()
                {
                    HairStyle = 41,
                    SkinVariant = 3,
                    HairColor = new Color(255, 255, 255),
                    EyeColor = new Color(180, 0, 0),
                    SkinColor = new Color(255, 212, 109),
                    ShirtColor = new Color(123, 0, 0),
                    UndershirtColor = new Color(38, 38, 38),
                    PantsColor = new Color(39, 39, 39),
                    ShoesColor = new Color(128, 0, 0)
                };
            }
        }

        
        public override void InitialInventory(out InitialItemDefinition[] InitialInventoryItems, ref InitialItemDefinition[] InitialEquipments)
	    {
		if (ModLoader.TryGetMod("ArknightsMod", out Mod ArknightsMod) && ArknightsMod.TryFind("DoctorJacket", out ModItem DoctorJacket) && ArknightsMod.TryFind("DoctorHood", out ModItem DoctorHood) && ArknightsMod.TryFind("DoctorPants", out ModItem DoctorPants))
        {
            InitialInventoryItems = new InitialItemDefinition[]
            {
                new InitialItemDefinition(676, 1),
                new InitialItemDefinition(533, 1),
                new InitialItemDefinition(1302, 9999),
                new InitialItemDefinition(188, 100),
            };
            InitialEquipments[11] = new InitialItemDefinition(DoctorJacket.Type);
            InitialEquipments[10] = new InitialItemDefinition(DoctorHood.Type);
            InitialEquipments[12] = new InitialItemDefinition(DoctorPants.Type);
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
