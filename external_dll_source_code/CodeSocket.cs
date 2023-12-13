

namespace Elanat
{
    public class CodeSocket
    {
        public string Coder(string Text)
        {
            CodeConnector code = new CodeConnector();
            return code.Coder(Text);
        }

        public string DeCoder(string Text)
        {
            CodeConnector code = new CodeConnector();
            return code.DeCoder(Text);
        }
    }
}