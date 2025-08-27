using System;
using System.Collections.Generic;

[Serializable]
public class FormulaData
{
    public int item1ID;
    public int item1Amount;
    public int item2ID;
    public int item2Amount;
    public int resID;
}

[Serializable]
public class FormulaList
{
    public List<FormulaData> formulaList;
}
