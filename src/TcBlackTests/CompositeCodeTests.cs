﻿using TcBlack;
using Xunit;

namespace TcBlackTests
{
    public class CompositeCodeTests
    {
        private readonly string lineEnding = "\n";
        private readonly string singleIndent = "    ";

        [Fact]
        public void FormatDeclaration()
        {
            string unformattedCode =
                "// Single line comments are also not formatted, yet\n" +
                "FUNCTION AddIntegers:DINT\n" +
                "VAR_INPUT\n" +
                "var1:      LREAL  :=9.81 ;      // Comment\n" +
                "var2  AT %Q*:  BOOL     ;   \n" +
                "\n\n\n" +
                "    {attribute 'hide'}\n" +
                "anotherBool : BOOL:=TRUE;\n" +
                "END_VAR\n\n\n";
            CompositeCode statements = new CompositeCode(
                unformattedCode: unformattedCode, 
                singleIndent: singleIndent, 
                lineEnding: lineEnding
            ).Tokenize();

            uint indents = 0;
            string actual = statements.Format(ref indents);
            string expected =
                "// Single line comments are also not formatted, yet\n" +
                "FUNCTION AddIntegers : DINT\n" +
                "VAR_INPUT\n" +
                "    var1 : LREAL := 9.81; // Comment\n" +
                "    var2 AT %Q* : BOOL;\n" +
                "\n" +
                "    {attribute 'hide'}\n" +
                "    anotherBool : BOOL := TRUE;\n" +
                "END_VAR\n";

            Assert.Equal(expected, actual);
        } 
    }
}
