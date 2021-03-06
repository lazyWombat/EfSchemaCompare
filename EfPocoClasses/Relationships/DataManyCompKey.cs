﻿#region licence
// =====================================================
// EfSchemeCompare Project - project to compare EF schema to SQL schema
// Filename: DataManyCompKey.cs
// Date Created: 2016/04/06
// 
// Under the MIT License (MIT)
// 
// Written by Jon Smith : GitHub JonPSmith, www.thereformedprogrammer.net
// =====================================================
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfPocoClasses.Relationships
{

    public class DataManyCompKey
    {
        [Key]
        [Column(Order = 1)]
        public int ManyKey1 { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid ManyKey2 { get; set; }

        //------------------------------------------
        //relationships

        public ICollection<DataTop> ManyParents { get; set; }
    }
}
