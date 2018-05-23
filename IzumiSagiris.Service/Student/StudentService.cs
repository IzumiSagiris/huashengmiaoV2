using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IzumiSagiris.Service.IzumiEntity;
using IzumiSagirisCommon.Worker;

namespace IzumiSagiris.Service.Student
{
    public class StudentService : IStudentInterFace
    {
        public StudentEntity GetStudent(long ID)
        {
            using (var context = new IzumiContext("CodeFirstDb"))
            {
                var student = context.Student.FirstOrDefault(t => t.StudentID == ID);
                return student;
            }
        }

        public UserEntity GetUser(string username,string password)
        {
            using (var context = new IzumiContext("CodeFirstDb"))
            {
                var user = context.User.FirstOrDefault(t => t.UserName == username && t.Password == password);
                return user;
            }
        }

        public long CreateStudent(StudentEntity student)
        {
            using (var context = new IzumiContext("CodeFirstDb"))
            {
                Func<long> func = () =>
                {
                    long studentID = Snowflake.Instance().GetId();                 
                    student.StudentID = studentID;

                    context.Student.Add(student);

                    context.SaveChanges();

                    return studentID;
                };

                return ExcuteTransaction(context, func);
            }
        }

        public long CreateUser(UserEntity user)
        {
            using (var context = new IzumiContext("CodeFirstDb"))
            {
                Func<long> func = () =>
                {
                    long UserID = Snowflake.Instance().GetId();
                    user.UserID = UserID;

                    context.User.Add(user);

                    context.SaveChanges();

                    return UserID;
                };

                return ExcuteTransaction(context, func);
            }
        }


        public long UpdateStudent(StudentEntity studentEntity)
        {
            using (var context = new IzumiContext("CodeFirstDb"))
            {
                Func<long> func = () =>
                {
                    DbEntityEntry<StudentEntity> entry =  context.Entry<StudentEntity>(studentEntity);
                    entry.State = EntityState.Unchanged;
                    entry.Property(t => t.StudentID).IsModified = false;
                    entry.Property(t => t.StudentName).IsModified = true;
                    entry.Property(t => t.Status).IsModified = true;

                    context.SaveChanges();

                    return studentEntity.StudentID;
                };

                return ExcuteTransaction(context, func);
            }
        }

        public long ExcuteTransaction(DbContext dbContext, Func<long> func)
        {
            long result = 0;
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    result = func();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }
    }
}
