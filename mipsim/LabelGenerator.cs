using System;

namespace mipsim
{
    public class LabelGenerator
    {
        int labelCounter;

        public LabelGenerator()
        {
           labelCounter = 0;
        }

        public string generateLabel()
        {
            string generatedLabel = "Label_" + labelCounter.ToString();
            labelCounter++;
            return generatedLabel;
        }
    }
}
