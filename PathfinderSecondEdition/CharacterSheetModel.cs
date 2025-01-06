using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderSecondEdition
{
    public class CharacterSheetModel
    {
        public int CharacterSheetModelId { get; set; }
        public int Level { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public AbilityScore AbilityScore { get; set; }
    }
}
