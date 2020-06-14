﻿namespace TcBlack
{
    public class EmptyLine : StatementBase
    {
        public EmptyLine(
            string unformattedCode,
            string singleIndent,
            string lineEnding
        ) : base(unformattedCode, singleIndent, lineEnding)
        {
        }

        public override string Format(ref uint indents)
        {
            return "";
        }
    }
}