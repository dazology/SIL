using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.Domain;

namespace SIL.DataLayer
{
    public class SILContext : DbContext,  ISilContext
    {
        public IDbSet<Website> Websites { get; set; }
        public IDbSet<Server> Servers { get; set; }
        public IDbSet<IP> Ips { get; set; }
        public IDbSet<Release> Releases { get; set; }
        public IDbSet<ReleaseInfo> ReleaseInfos { get; set; }
        public IDbSet<ReleaseHistory> ReleaseHistories { get; set; }
        public IDbSet<Checklist> Checklists { get; set; }
        public IDbSet<CustomChecklist> CustomChecklists { get; set; }
        public IDbSet<ChecklistQuestion> ChecklistQuestions { get; set; }
        public IDbSet<ChecklistType> ChecklistTypes { get; set; }
        public IDbSet<ReleaseType> ReleaseTypes { get; set; }
        public IDbSet<Contact> Contacts { get; set; }
        public IDbSet<AuditLog> AuditLog { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Customer> Companies { get; set; }
  

        public virtual void Commit()
        {
            base.SaveChanges();
        }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            //modelBuilder.Entity<Website>()
            // .HasOptional<DatabaseInfo>(u => u.DatabaseInfos)
            //.WithOptionalDependent(c => c.Websites).Map(p => p.MapKey("DatabaseId"));

            //modelBuilder.Entity<Server>()
            //.HasOptional<DatabaseInfo>(u => u.DatabaseInfos)
            //.WithOptionalDependent(c => c.Servers).Map(p => p.MapKey("ServerId"));


            //modelBuilder.Entity<Website>()
            //    .HasOptional<Company>(u => u.Companies)
            //    .WithRequired(cw => cw.Websites);

        }


          public SILContext()
              : base("name=SILDev")
          {

          }


        //// This is overridden to prevent someone from calling SaveChanges without specifying the user making the change
        //public override int SaveChanges()
        //{
        //    throw new InvalidOperationException("User ID must be provided");
        //}

        //public int SaveChanges(string userId)
        //{
        //    // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
        //    foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == System.Data.EntityState.Added || p.State == System.Data.EntityState.Deleted || p.State == System.Data.EntityState.Modified))
        //    {
        //        // For each changed record, get the audit record entries and add them
        //        foreach (AuditLog x in GetAuditRecordsForChange(ent, userId))
        //        {
        //            this.AuditLog.Add(x);
        //        }
        //    }

        //    // Call the original SaveChanges(), which will save both the changes made and the audit records
        //    return base.SaveChanges();
        //}

        //private List<AuditLog> GetAuditRecordsForChange(DbEntityEntry dbEntry, string userId)
        //{
        //    List<AuditLog> result = new List<AuditLog>();

        //    DateTime changeTime = DateTime.UtcNow;

        //    // Get the Table() attribute, if one exists
        //    TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;

        //    // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
        //    string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

        //    // Get primary key value (If you have more than one key column, this will need to be adjusted)
        //    string keyName = dbEntry.Entity.GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;

        //    if (dbEntry.State == System.Data.EntityState.Added)
        //    {
        //        // For Inserts, just add the whole record
        //        // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()
        //        result.Add(new AuditLog()
        //        {
        //            AuditLogID = Guid.NewGuid(),
        //            UserID = userId,
        //            EventDateUTC = changeTime,
        //            EventType = "A", // Added
        //            TableName = tableName,
        //            RecordID = dbEntry.CurrentValues.GetValue<object>(keyName).ToString(),  // Again, adjust this if you have a multi-column key
        //            ColumnName = "*ALL",    // Or make it nullable, whatever you want
        //            NewValue = (dbEntry.CurrentValues.ToObject() is IDescribableEntity) ? (dbEntry.CurrentValues.ToObject() as IDescribableEntity).Describe() : dbEntry.CurrentValues.ToObject().ToString()
        //        }
        //            );
        //    }
        //    else if (dbEntry.State == System.Data.EntityState.Deleted)
        //    {
        //        // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
        //        result.Add(new AuditLog()
        //        {
        //            AuditLogID = Guid.NewGuid(),
        //            UserID = userId,
        //            EventDateUTC = changeTime,
        //            EventType = "D", // Deleted
        //            TableName = tableName,
        //            RecordID = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
        //            ColumnName = "*ALL",
        //            NewValue = (dbEntry.OriginalValues.ToObject() is IDescribableEntity) ? (dbEntry.OriginalValues.ToObject() as IDescribableEntity).Describe() : dbEntry.OriginalValues.ToObject().ToString()
        //        }
        //            );
        //    }
        //    else if (dbEntry.State == System.Data.EntityState.Modified)
        //    {
        //        foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
        //        {
        //            // For updates, we only want to capture the columns that actually changed
        //            if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
        //            {
        //                result.Add(new AuditLog()
        //                {
        //                    AuditLogID = Guid.NewGuid(),
        //                    UserID = userId,
        //                    EventDateUTC = changeTime,
        //                    EventType = "M",    // Modified
        //                    TableName = tableName,
        //                    RecordID = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
        //                    ColumnName = propertyName,
        //                    OriginalValue = dbEntry.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntry.OriginalValues.GetValue<object>(propertyName).ToString(),
        //                    NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
        //                }
        //                    );
        //            }
        //        }
        //    }
        //    // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

        //    return result;
        //}


          public void SetModified(object entity)
          {
              Entry(entity).State = System.Data.EntityState.Modified;
          }

          public void SetAdd(object entity)
          {
              Entry(entity).State = System.Data.EntityState.Added;
          }
    }
}

   