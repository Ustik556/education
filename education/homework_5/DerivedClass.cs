using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_5
{
    public class DerivedClass : IntermediateClass, IMyCloneable<DerivedClass>, ICloneable
    {
        public DateTime CreatedAt { get; set; }

        // Добавляем поле и переопределяем DeepCopy
        public override DerivedClass DeepCopy()
        {
            var copy = base.DeepCopy() as DerivedClass ?? new DerivedClass();
            copy.CreatedAt = this.CreatedAt;
            return copy;
        }

        // Стандартный интерфейс ICloneable
        object ICloneable.Clone()
        {
            return DeepCopy();
        }
    }

   
}
