using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_5
{
    public class FinalClass : DerivedClass, IMyCloneable<FinalClass>, ICloneable
    {
        public bool IsActive { get; set; }

        // Завершаем цепочку клонирования добавлением последнего свойства
        public override FinalClass DeepCopy()
        {
            var copy = base.DeepCopy() as FinalClass ?? new FinalClass();
            copy.IsActive = this.IsActive;
            return copy;
        }

        // Стандартный интерфейс ICloneable
        object ICloneable.Clone()
        {
            return DeepCopy();
        }
    }
}
