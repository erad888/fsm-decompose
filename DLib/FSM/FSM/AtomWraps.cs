using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSM
{
    public class StructAtom<T>: FSMAtomBase where T: class
    {
        public static explicit operator StructAtom<T>(T value)
        {
            return new StructAtom<T>(value);
        }

        public StructAtom(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override bool Equals(object obj)
        {
            StructAtom<T> other = obj as StructAtom<T>;
            if (other == null)
                return false;
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string KeyName
        {
            get { return Value.ToString(); }
        }

        public override string ToString()
        {
            return KeyName;
        }
    }

    public class CompositeStructAtom : FSMAtomBase
    {
        public CompositeStructAtom(params Type[] ValuesTypes)
        {
            if(ValuesTypes == null)
                throw new ArgumentNullException("ValuesTypes");
            if(ValuesTypes.Length < 2)
                throw new ArgumentException("Two or more types expected", "ValuesTypes");
            types = ValuesTypes;
            values = new FSMAtomBase[ValuesTypes.Length];
        }

        public IEnumerable<FSMAtomBase> Values
        {
            get { return values; }
        }
        public IEnumerable<Type> ValuesTypes
        {
            get { return types;}
        }
        private Type[] types;
        private FSMAtomBase[] values;

        public FSMAtomBase this[int index]
        {
            // Если возникнет выход за границы, то его пропалит индексатор класса Array
            get
            {
                return values[index];
            }
            set
            {
                if (values.GetType().Equals(types[index]))
                    values[index] = value;
            }
        }
    
        public string KeyName
        {
            get
            {
                string result = string.Empty;
                foreach (var value in values)
                {
                    result += value.KeyName;
                }
                return result;
            }
        }
    }
}
