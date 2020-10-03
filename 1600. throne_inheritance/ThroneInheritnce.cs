using System.Collections.Generic;

public class ThroneInheritance {
    private string kingName;
    List<string> inheritance;
    private Dictionary<string, List<string>> peopleBirth = new Dictionary<string, List<string>>();
    private HashSet<string> peopleDead = new HashSet<string>();
    
    
    public ThroneInheritance(string kingName) {
        this.kingName = kingName;
        peopleBirth[kingName] = new List<string>();
    }
    
    public void Birth(string parentName, string childName) {        
        peopleBirth[parentName].Add(childName);
        peopleBirth[childName] = new List<string>();
    }
    
    public void Death(string name) {
        peopleDead.Add(name);
    }
    
    public IList<string> GetInheritanceOrder() {
        inheritance = new List<string>();
        BuildInheritance(kingName);
        return inheritance;
    }

    private void BuildInheritance(string name) {
        if (!peopleDead.Contains(name)) inheritance.Add(name);
        foreach(string child in peopleBirth[name]) {
            BuildInheritance(child);
        }
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */