using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    public static class GlobalStageDirectory
    {
        #region Stage Values

        private static readonly Int32 BATTLEFIELD = 0;
        private static readonly Int32 FINAL_DEST = 1;
        private static readonly Int32 DELFINO = 2;
        private static readonly Int32 DRACULA = 3;
        private static readonly Int32 CAVERN = 4;
        private static readonly Int32 PEACH_CASTLE = 5;
        private static readonly Int32 KONGO64 = 6;
        private static readonly Int32 RUMBLE_FALLS = 7;// ---
        private static readonly Int32 PIRATE_SHIP = 8;
        private static readonly Int32 HYRULE_CASTLE = 9;
        private static readonly Int32 NORFAIR = 10;
        private static readonly Int32 FRIGATE = 11;
        private static readonly Int32 YOSHI_BRAWL = 12;
        private static readonly Int32 HALBERD = 13;
        private static readonly Int32 BAD_STAGE = 14;// ---
        private static readonly Int32 PS2 = 15;// ---
        private static readonly Int32 SAFFRON64 = 16;// ---
        private static readonly Int32 PTAD = 17;             // ---
        private static readonly Int32 INFIN_GLACIER = 18;
        private static readonly Int32 FZ2 = 19;
        private static readonly Int32 CASTLE_SEIGE = 20;// ---
        private static readonly Int32 WW = 21;
        private static readonly Int32 DP = 22;
        private static readonly Int32 SKYWORLD = 23;
        private static readonly Int32 FOD = 24;
        private static readonly Int32 NPC = 25;
        private static readonly Int32 SMASHVILLE = 26;
        private static readonly Int32 SMI = 27;
        private static readonly Int32 GREEN_HILL = 28;
        private static readonly Int32 PICTOCHAT = 29;
        private static readonly Int32 HANENBOW = 30;// ---
        private static readonly Int32 TEMPLE = 31;
        private static readonly Int32 YOSHI_MELEE = 32;
        private static readonly Int32 SKYLOFT = 33;// ---
        private static readonly Int32 ONETT = 34;
        private static readonly Int32 DREAMLAND = 35;
        private static readonly Int32 RBCRUISE = 36;
        private static readonly Int32 CORNERIA = 37;
        private static readonly Int32 BIG_BLUE = 38; // ---
        private static readonly Int32 BRINSTAR = 39;
        private static readonly Int32 PS1 = 40;
        private static readonly Int32 TRAINING_ROOM = 43;

        #endregion

        #region Stage List

        public static List<Stage> STAGE_LIST = new List<Stage>()
        {
            new Stage("Battlefield", BATTLEFIELD),
            new Stage("FinalDestination", FINAL_DEST),
            new Stage("DelfinePlaza", DELFINO),
            new Stage("DraculasCastle", DRACULA),
            new Stage("MetalCavern", CAVERN),
            new Stage("PeachsCastle", PEACH_CASTLE),
            new Stage("KongoJungle64", KONGO64),
            new Stage("RumbleFalls", RUMBLE_FALLS),
            new Stage("PirateShip", PIRATE_SHIP),
            new Stage("HyruleCastle", HYRULE_CASTLE),
            new Stage("Norfair", NORFAIR),
            new Stage("FrigateOrpheon", FRIGATE),
            new Stage("YoshisIsland", YOSHI_BRAWL),
            new Stage("Halberd", HALBERD),
            new Stage("LylatCruise", BAD_STAGE),
            new Stage("PokemonStadium2", PS2),
            new Stage("Saffron64", SAFFRON64),
            new Stage("PortTownAeroDrive", PTAD),
            new Stage("InfiniteGlacier", INFIN_GLACIER),
            new Stage("FlatZone2", FZ2),
            new Stage("CastleSeige", CASTLE_SEIGE),
            new Stage("WariowareInc", WW),
            new Stage("DistantPlanet", DP),
            new Stage("Skyworld", SKYWORLD),
            new Stage("FountainofDreams", FOD),
            new Stage("NewPorkCity", NPC),
            new Stage("Smashville", SMASHVILLE),
            new Stage("ShadowMosesIsland", SMI),
            new Stage("GreenHillZone", GREEN_HILL),
            new Stage("PictroChat", PICTOCHAT),
            new Stage("Hanenbow", HANENBOW),
            new Stage("Temple", TEMPLE),
            new Stage("YoshisIsland", YOSHI_MELEE),
            new Stage("Skyloft", SKYLOFT),
            new Stage("Onett", ONETT),
            new Stage("Dreamland", DREAMLAND),
            new Stage("RainbowCruise", RBCRUISE),
            new Stage("Corneria", CORNERIA),
            new Stage("BigBlue", BIG_BLUE),
            new Stage("Brinstar", BRINSTAR),
            new Stage("PokemonStadium1", PS1),
            new Stage("TrainingRoom", TRAINING_ROOM)
        };

        private static Dictionary<Int32, Stage> m_valueToStageDict = new Dictionary<Int32, Stage>
        {
            {BATTLEFIELD, new Stage("Battlefield", BATTLEFIELD)},
            {FINAL_DEST, new Stage("Final Destination", FINAL_DEST)},
            {DELFINO, new Stage("Delfine Plaza", DELFINO)},
            {DRACULA, new Stage("Dracula's Castle", DRACULA)},
            {CAVERN, new Stage("Metal Cavern", CAVERN)},
            {PEACH_CASTLE, new Stage("Peach's Castle", PEACH_CASTLE)},
            {KONGO64, new Stage("Kongo Jungle 64", KONGO64)},
            {RUMBLE_FALLS, new Stage("Rumble Falls", RUMBLE_FALLS)},
            {PIRATE_SHIP, new Stage("Pirate Ship", PIRATE_SHIP)},
            {HYRULE_CASTLE, new Stage("Hyrule Castle", HYRULE_CASTLE)},
            {NORFAIR, new Stage("Norfair", NORFAIR)},
            {FRIGATE, new Stage("Frigate Orpheon", FRIGATE)},
            {YOSHI_BRAWL, new Stage("Yoshi's Island", YOSHI_BRAWL)},
            {HALBERD, new Stage("Halberd", HALBERD)},
            {BAD_STAGE, new Stage("Lylat Cruise", BAD_STAGE)},
            {PS2, new Stage("Pokemon Stadium 2", PS2)},
            {SAFFRON64, new Stage("Saffron 64", SAFFRON64)},
            {PTAD, new Stage("Port Town Aero Drive", PTAD)},
            {INFIN_GLACIER, new Stage("Infinite Glacier", INFIN_GLACIER)},
            {FZ2, new Stage("Flat Zone 2", FZ2)},
            {CASTLE_SEIGE, new Stage("Castle Seige", CASTLE_SEIGE)},
            {WW, new Stage("Warioware Inc.", WW)},
            {DP, new Stage("Distant Planet", DP)},
            {SKYWORLD, new Stage("Skyworld", SKYWORLD)},
            {FOD, new Stage("Fountain of Dreams", FOD)},
            {NPC, new Stage("New Pork City", NPC)},
            {SMASHVILLE, new Stage("Smashville", SMASHVILLE)},
            {SMI, new Stage("Shadow Moses Island", SMI)},
            {GREEN_HILL, new Stage("Green Hill Zone", GREEN_HILL)},
            {PICTOCHAT, new Stage("PictroChat", PICTOCHAT)},
            {HANENBOW, new Stage("Hanenbow", HANENBOW)},
            {TEMPLE, new Stage("Temple", TEMPLE)},
            {YOSHI_MELEE, new Stage("Yoshi's Island", YOSHI_MELEE)},
            {SKYLOFT, new Stage("Skyloft", SKYLOFT)},
            {ONETT, new Stage("Onett", ONETT)},
            {DREAMLAND, new Stage("Dreamland", DREAMLAND)},
            {RBCRUISE, new Stage("Rainbow Cruise", RBCRUISE)},
            {CORNERIA, new Stage("Corneria", CORNERIA)},
            {BIG_BLUE, new Stage("Big Blue", BIG_BLUE)},
            {BRINSTAR, new Stage("Brinstar", BRINSTAR)},
            {PS1, new Stage("Pokemon Stadium 1", PS1)},
            {TRAINING_ROOM, new Stage("Training Room", TRAINING_ROOM)}
        };

        #endregion
        public static Stage GetStage(Int32 value)
        {
            return m_valueToStageDict[value];
        }

        public static Stage GetStage(String name)
        {
            Stage retValue = null;

            foreach (Stage stage in STAGE_LIST)
            {
                if (stage.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    retValue = stage;
                }
            }

            return retValue;
        }
    }
}
