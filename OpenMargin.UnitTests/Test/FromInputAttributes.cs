﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixie;
using System.Reflection;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace MarkG1968.OpenMargin.UnitTests.Test
{
    class FromInputAttributes : ParameterSource
    {
        public IEnumerable<object[]> GetParameters(MethodInfo method)
        {
            return method.GetCustomAttributes<InputAttribute>(true).Select(input => input.Parameters);
        }
    }
}
