using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace DAO
{
    public interface RepositorioBase
    {
        void Insert(EntidadeBase e);
        
        void Update(EntidadeBase e);
    }
}
