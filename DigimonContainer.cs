using Terraria.ModLoader;
using terraguardians;
using DocterMain.Companions;

namespace DocterMain
{
public class DigimonContainer : CompanionContainer
{
	public const uint Docter = 0u;
	public const uint W = 1u;
	public const uint Neng = 2u;
	public const uint TexastheOmertosa = 3u;
	public const uint Surtr = 4u;
	public const uint ACE = 5u;
	public const uint Scout = 6u;
	public const uint Closure = 7u;
	public const uint JessicatheLiberated = 8u;
	public override CompanionBase GetCompanionDB(uint ID)
	{
		return (CompanionBase)(ID switch
		{
			0u => new DocterBase(), 
			1u => new WBase(), 
			2u => new NengBase(), 
			3u => new TexastheOmertosaBase(), 
			4u => new SurtrBase(), 
			5u => new ACEBase(), 
			6u => new ScoutBase(), 
			7u => new ClosureBase(), 
			8u => new JessicatheLiberatedBase(), 
			_ => ((CompanionContainer)this).GetCompanionDB(ID), 
		});
	}
}
}