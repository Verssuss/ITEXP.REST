﻿using Domain.Configurations.Common;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    public class CommentConfig : BaseEntityConfig<Comment>
    {
        protected override void Config(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Todo)
                   .WithMany(x => x.Comments)
                   .HasPrincipalKey(x => x.Id)
                   .HasForeignKey(x=> x.TodoId);

            builder.HasData(new Comment() { Id = 1, TodoId = 1, Text = "2-3шт." });
        }
    }
}