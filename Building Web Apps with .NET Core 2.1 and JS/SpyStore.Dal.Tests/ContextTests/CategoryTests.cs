using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Initialization;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.ContextTests
{
    [Collection("SpyStore.Dal")]
    public class CategoryTests : IDisposable
    {
        public CategoryTests()
        {
        }
        public void Dispose()
        {
        }
    }
}
