using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class TextWriterLogger : Logger
    {
        private readonly TextWriter _textWriter;

        public TextWriterLogger(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        #region Logger Members

        public void informational(string message)
        {
            _textWriter.WriteLine(message);
        }

        #endregion
    }
}