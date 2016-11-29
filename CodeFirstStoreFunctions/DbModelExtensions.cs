// Copyright (c) Pawel Kadluczka, Inc. All rights reserved. See License.txt in the project root for license information.

namespace CodeFirstStoreFunctions
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Mapping;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public static class DbModelExtensions
    {
        public static IEnumerable<PropertyMapping> GetEntityTypePropertyMappings(this DbModel model, EntityType entityType)
        {
            var entityTypeMapping =
                model.ConceptualToStoreMapping.EntitySetMappings.SelectMany(s => s.EntityTypeMappings)
                    .Single(t => t.EntityType == entityType);

            return
                entityTypeMapping.Fragments.SelectMany(f => f.PropertyMappings)
                    .Where(p => entityType.Properties.Contains(p.Property));
        }
    }
}