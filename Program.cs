using System;
using System.Collections.Generic;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args) {
            ThroneInheritance t = new ThroneInheritance("king");
            t.Birth("king", "andy"); // order: king > andy
            t.GetInheritanceOrder(); // return ["king", "andy", "matthew", "bob", "alex", "asha", "catherine"]
            t.Death("andy"); // order: king > andy > bob
            t.GetInheritanceOrder(); // return ["king", "andy", "matthew", "bob", "alex", "asha", "catherine"]
            t.Birth("king", "catherine"); // order: king > andy > bob > catherine
            t.Birth("catherine", "matthew"); // order: king > andy > matthew > bob > catherine
            t.Birth("matthew", "alex"); // order: king > andy > matthew > bob > alex > catherine
            t.GetInheritanceOrder(); // return ["king", "andy", "matthew", "bob", "alex", "asha", "catherine"]
            t.Birth("king", "luis");
            t.GetInheritanceOrder();
        }
    }
}



