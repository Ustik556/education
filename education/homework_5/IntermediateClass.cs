using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_5
{
    public class IntermediateClass : BaseClass, IMyCloneable<IntermediateClass>
    {
        public string Name { get; set; }

        // Переопределяем метод DeepCopy для нашего нового поля
        public override IntermediateClass DeepCopy()
        {
            var copy = base.DeepCopy() as IntermediateClass ?? new IntermediateClass();
            copy.Name = this.Name;
            return copy;
        }

    }
}
