using System.Collections.Generic;

namespace CalcEngine
{
    public static class Logical
    {
        public static void Register(CalcEngine ce)
        {
            ce.RegisterFunction("E", 1, int.MaxValue, And);
            ce.RegisterFunction("OU", 1, int.MaxValue, Or);
            ce.RegisterFunction("NAO", 1, Not);
            ce.RegisterFunction("SE", 3, If);
            ce.RegisterFunction("VERDADEIRO", 0, True);
            ce.RegisterFunction("FALSO", 0, False);
        }
#if DEBUG
        public static void Test(CalcEngine ce)
        {
            ce.Test("E(Verdadeiro, Verdadeiro)", true);
            ce.Test("E(Verdadeiro, Falso)", false);
            ce.Test("E(Falso, Verdadeiro)", false);
            ce.Test("E(Falso, Falso)", false);
            ce.Test("OU(Verdadeiro, Verdadeiro)", true);
            ce.Test("OU(Verdadeiro, Falso)", true);
            ce.Test("OU(Falso, Verdadeiro)", true);
            ce.Test("OU(Falso, Falso)", false);
            ce.Test("NAO(Falso)", true);
            ce.Test("NAO(Verdadeiro)", false);
            ce.Test("SE(5 > 4, Verdadeiro, Falso)", true);
            ce.Test("SE(5 > 14, Verdadeiro, Falso)", false);
            ce.Test("VERDADEIRO()", true);
            ce.Test("FALSO()", false);
        }
#endif
        static object And(List<Expression> p)
        {
            var b = true;
            foreach (var v in p)
            {
                b = b && (bool)v;
            }
            return b;
        }
        static object Or(List<Expression> p)
        {
            var b = false;
            foreach (var v in p)
            {
                b = b || (bool)v;
            }
            return b;
        }
        static object Not(List<Expression> p)
        {
            return !(bool)p[0];
        }
        static object If(List<Expression> p)
        {
            return (bool)p[0] 
                ? p[1].Evaluate() 
                : p[2].Evaluate();
        }
        static object True(List<Expression> p)
        {
            return true;
        }
        static object False(List<Expression> p)
        {
            return false;
        }
    }
}
