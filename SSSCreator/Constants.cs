using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    class Constants
    {
        //These offset values are used for verfication of the stage size bytes.
        //Starting and ending at the designated values.
        public const long FIRST_PAGE_START_OFFSET = 47232;
        public const long FIRST_PAGE_END_OFFSET = 47247;

        public const long SECOND_PAGE_START_OFFSET = 47264;
        public const long SECOND_PAGE_END_OFFSET = 47279;


        // The 255 values in the verfication arrays are placeholders. During verification these values are skipped as they can vary.
        public static readonly Byte[] FIRST_PAGE_VERIFICATION = { 0, 107, 146, 156, 0, 0, 0, 255, 6, 107, 153, 216, 0, 0, 0, 255 };
        public static readonly Byte[] SECOND_PAGE_VERIFICATION = { 0, 107, 146, 164, 0, 0, 0, 255, 6, 107, 154, 88, 0, 0, 0, 255 };

        // There is a finite number of page sizes that both page 1 and page 2 can be at the current time.
        public static readonly Byte[] POSSIBLE_STAGE_SIZES = { 10, 11, 12, 13, 14, 21 };

        // Max number of stages for one page
        public const Int32 MAX_STAGES_PAGE_ONE = 14;
        public const Int32 MAX_STAGES_PAGE_TWO = 21;

        // Starting stage offsets for stage lists
        public const Int32 PAGE_ONE_STAGE_LIST_START_OFFSET = 47248;
        public const Int32 PAGE_TWO_STAGE_LIST_START_OFFSET = 47280;

        // Page One stage Sizs OFfsets
        public const Int32 PAGE_ONE_STAGE_SIZE_OFFSET_1 = 47239;
        public const Int32 PAGE_ONE_STAGE_SIZE_OFFSET_2 = 47247;

        // Page Two Stage Size Offsets
        public const Int32 PAGE_TWO_STAGE_SIZE_OFFSET_1 = 47271;
        public const Int32 PAGE_TWO_STAGE_SIZE_OFFSET_2 = 47279;

        // Constant Stage Values

        public const Int32 BATTLEFIELD = 0;
        public const Int32 FINAL_DEST = 1;
        public const Int32 DELFINO = 2;
        public const Int32 DRACULA = 3;
        public const Int32 CAVERN = 4;
        public const Int32 PEACH_CASTLE = 5;
        public const Int32 KONGO64 = 6;
        public const Int32 RUMBLE_FALLS = 7;// ---
        public const Int32 PIRATE_SHIP = 8;
        public const Int32 HYRULE_CASTLE = 9;
        public const Int32 NORFAIR = 10;
        public const Int32 FRIGATE = 11;
        public const Int32 YOSHI_BRAWL = 12;
        public const Int32 HALBERD = 13;
        public const Int32 BAD_STAGE = 14;// ---
        public const Int32 PS2 = 15;// ---
        public const Int32 SAFFRON64 = 16;// ---
        public const Int32 PTAD = 17;             // ---
        public const Int32 INFIN_GLACIER = 18;
        public const Int32 FZ2 = 19;
        public const Int32 CASTLE_SEIGE = 20;// ---
        public const Int32 WW = 21;
        public const Int32 DP = 22;
        public const Int32 SKYWORLD = 23;
        public const Int32 FOD = 24;
        public const Int32 NPC = 25;
        public const Int32 SMASHVILLE = 26;
        public const Int32 SMI = 27;
        public const Int32 GREEN_HILL = 28;
        public const Int32 PICTOCHAT = 29;
        public const Int32 HANENBOW = 30;// ---
        public const Int32 TEMPLE = 31;
        public const Int32 YOSHI_MELEE = 32;
        public const Int32 SKYLOFT = 33;// ---
        public const Int32 ONETT = 34;
        public const Int32 DREAMLAND = 35;
        public const Int32 RBCRUISE = 36;
        public const Int32 CORNERIA = 37;
        public const Int32 BIG_BLUE = 38; // ---
        public const Int32 BRINSTAR = 39;
        public const Int32 PS1 = 40;
        public const Int32 TRAINING_ROOM = 43;

        // Stage Dictionary
        public static readonly List<Stage> STAGE_LIST = new List<Stage>()
        {
            new Stage("Battlefield", BATTLEFIELD),
            new Stage("Final Destination", FINAL_DEST),
            new Stage("Delfine Plaza", DELFINO),
            new Stage("Dracula's Castle", DRACULA),
            new Stage("Metal Cavern", CAVERN),
            new Stage("Peach's Castle", PEACH_CASTLE),
            new Stage("Kongo Jungle 64", KONGO64),
            new Stage("Rumble Falls", RUMBLE_FALLS),
            new Stage("Pirate Ship", PIRATE_SHIP),
            new Stage("Hyrule Castle", HYRULE_CASTLE),
            new Stage("Norfair", NORFAIR),
            new Stage("Frigate Orpheon", FRIGATE),
            new Stage("Yoshi's Island", YOSHI_BRAWL),
            new Stage("Halberd", HALBERD),
            new Stage("Lylat Cruise", BAD_STAGE),
            new Stage("Pokemon Stadium 2", PS2),
            new Stage("Saffron 64", SAFFRON64),
            new Stage("Port Town Aero Drive", PTAD),
            new Stage("Infinite Glacier", INFIN_GLACIER),
            new Stage("Flat Zone 2", FZ2),
            new Stage("Castle Seige", CASTLE_SEIGE),
            new Stage("Warioware Inc.", WW),
            new Stage("Distant Planet", DP),
            new Stage("Skyworld", SKYWORLD),
            new Stage("Fountain of Dreams", FOD),
            new Stage("New Pork City", NPC),
            new Stage("Smashville", SMASHVILLE),
            new Stage("Shadow Moses Island", SMI),
            new Stage("Green Hill Zone", GREEN_HILL),
            new Stage("PictroChat", PICTOCHAT),
            new Stage("Hanenbow", HANENBOW),
            new Stage("Temple", TEMPLE),
            new Stage("Yoshi's Island", YOSHI_MELEE),
            new Stage("Skyloft", SKYLOFT),
            new Stage("Onett", ONETT),
            new Stage("Dreamland", DREAMLAND),
            new Stage("Rainbow Cruise", RBCRUISE),
            new Stage("Corneria", CORNERIA),
            new Stage("Big Blue", BIG_BLUE),
            new Stage("Brinstar", BRINSTAR),
            new Stage("Pokemon Stadium 2", PS2),
            new Stage("Training Room", TRAINING_ROOM)
        };
        


    }
}
