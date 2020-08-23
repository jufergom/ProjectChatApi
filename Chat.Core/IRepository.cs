using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.CORE
{
    public interface IRepository<Entity>
    {
        Entity Add(Entity entity);

        IQueryable<Entity> All();

        int saveChanges();
    }
}
