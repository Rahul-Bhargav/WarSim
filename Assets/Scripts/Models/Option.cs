using System.Collections.Generic;

public class Option
{
    public List<string> children { get; set; }
    public string _id { get; set; }
    public string name { get; set; }
    public string parent { get; set; }
    public bool isLeaf { get; set; }
    public Impact impact { get; set; }
}