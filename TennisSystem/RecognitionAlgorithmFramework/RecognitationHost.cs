using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecognitionAlgorithmFramework
{
    public class RecognitationHost
    {
        private static RecognitationHost _host;

        static RecognitationHost()
        {

        }

        public static RecognitationHost Instance
        {
            get { return _host; }
        }
    }
}
