using System;
using System.Diagnostics;
using Jint;

namespace MomentJs.Net.Globalization
{
    public abstract class Javascript
    {
        protected Javascript(string javascriptFunction)
        {
            JavascriptFunction = javascriptFunction;
        }

        internal string JavascriptFunction { get; }

        public override string ToString()
        {
            return JavascriptFunction;
        }

        public string Format(int value)
        {
            try
            {
                Engine engine = new Engine();
#if DEBUG
                engine.SetValue("console", new
                {
                    log = new Action<object>(x => Debug.WriteLine(x))
                });
#endif
                string javascript = JavascriptFunction.Trim();
                string functionName;
                if (javascript.StartsWith("function"))
                    functionName = javascript.Substring(8, javascript.IndexOf('(', 8) - 8).Trim();
                else
                    return value.ToString();

                if (string.IsNullOrWhiteSpace(functionName))
                {
                    functionName = "fn";
                    javascript = javascript.Insert(8, " " + functionName);
                }

                return engine.Execute(javascript).GetValue(functionName).Invoke(value).AsString();
            }
            catch
            {
                return value.ToString();
            }
        }
    }
    public class Ordinal : Javascript
    {
        public Ordinal(string javascriptFunction) 
            : base(javascriptFunction)
        {
        }

        public static implicit operator string(Ordinal ordinal)
        {
            return ordinal.JavascriptFunction;
        }

        public static implicit operator Ordinal(string ordinal)
        {
            return new Ordinal(ordinal);
        }
    }
}