﻿using BO;

namespace DL.Mappings
{
    public interface IMappingProvider<T, T1>
        where T : Base
    {


        T Map(T1 dbitem);

        T1 Map(T item);
        // Core.Domian.Settings.Rlam Map(Sql.Reason dbitem);

        //Core.Domian.Transactions.Modules module(Sql.Module item);
    }
}
