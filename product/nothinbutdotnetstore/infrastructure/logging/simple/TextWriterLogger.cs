using System;
using System.IO;
using System.Text;

namespace nothinbutdotnetstore.infrastructure.logging.simple
{
    public class TextWriterLogger : Logger
    {
    	private readonly TextWriter Tw;
    	private readonly StringBuilder Sb;

    	public TextWriterLogger(TextWriter tw)
    	{
    		Tw = tw;
    	}

    	public void informational(string message)
        {
			Tw.WriteLine(message);
        }
    }
}