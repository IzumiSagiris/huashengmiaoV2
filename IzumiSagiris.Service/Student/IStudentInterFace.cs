using IzumiSagiris.Service.IzumiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagiris.Service.Student
{
    public interface IStudentInterFace
    {
        StudentEntity GetStudent(long ID);

        UserEntity GetUser(string username, string password);

        long CreateStudent(StudentEntity studentEntity);

        long UpdateStudent(StudentEntity studentEntity);

        long CreateUser(UserEntity user);
    }

}
