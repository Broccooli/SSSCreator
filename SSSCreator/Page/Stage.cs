using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSSCreator
{
    class Stage : IEquatable<Stage>
    {
        public String Name { get; private set; }
        public Int32 Value { get; private set; }

        public Stage(String name, Int32 value)
        {
            Name = name;
            Value = value;
        }

        public Stage(Stage stage)
        {
            Name = stage.Name;
            Value = stage.Value;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Stage other)
        {
            return (this.Value == other.Value);
        }
    }
}
