namespace FSM
{
    public class ElementInfo:IStringKeyable
    {
        public string Text { get; set; }
        public string KeyName { get; protected set; }

    }

    public class FSMInfo : ElementInfo
    {
        public FSM Element { get; set; }

        public FSMInfo(FSM element, string KeyName)
        {
            Element = element;
            this.KeyName = KeyName;
        }
    }
}