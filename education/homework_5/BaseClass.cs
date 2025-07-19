using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace education.homework_5
{
    public class BaseClass : ICloneable, IMyCloneable<BaseClass>
    {
        public int Id { get; set; }

        // Метод глубокой копии (создаем новый объект)
        public virtual BaseClass DeepCopy()
        {
            return new BaseClass() { Id = this.Id };
        }

        // Реализуем стандартный интерфейс ICloneable
        object ICloneable.Clone()
        {
            return DeepCopy(); // Используем наш метод DeepCopy
        }
    }
}

    
