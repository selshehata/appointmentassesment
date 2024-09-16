﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Application
{
    public interface IMapperContainer
    {
        TDestination Map<TSource, TDestination>(TSource source);
        IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source);
    }
}
