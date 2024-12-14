using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityGraduate
{
    public class AdministratorManager
    {
        public Administrator Login(Administrator admin)
        {
            return AdministratorService.Login(admin);
        }
         public  Administrator GetAdminInfo(Administrator admin)
        {
            return AdministratorService.GetAdminInfo(admin);
        }
        public bool UpdateAdminInfo(Administrator admin)
         {
             return AdministratorService.UpdateAdminInfo(admin);
         }
        public  bool UpdateAllStudentNullPhoto(string urlImage)
        {
            return AdministratorService.UpdateAllStudentNullPhoto(urlImage);
        }
        public  bool UpdateAllTeacherNullPhoto(string urlImage)
        {
            return AdministratorService.UpdateAllTeacherNullPhoto(urlImage);
        }
        public  bool UpdateAllAdminNullPhoto(string urlImage)
        {
            return AdministratorService.UpdateAllAdminNullPhoto(urlImage);
        }
        public  bool DeleteAllStudentWishs()
        {
            return AdministratorService.DeleteAllStudentWishs();
        }
        public  bool AllStudentWishToStart()
        {
            return AdministratorService.AllStudentWishToStart();
        }
        public  bool UpdateAllStudentGuideTeacherToNull()
        {
            return AdministratorService.UpdateAllStudentGuideTeacherToNull();
        }
        public  bool UpdateSystemDate(SystemDate sd)
        {
            return AdministratorService.UpdateSystemDate(sd);
        }
        public  bool InsertSystemDate(SystemDate sd)
        {
            return AdministratorService.InsertSystemDate(sd);
        }
         public  SystemDate GetSystemDate()
        {
            return AdministratorService.GetSystemDate();
        }
        public  bool UpdateAllTeacherNullSex(string sex)
        {
            return AdministratorService.UpdateAllTeacherNullSex(sex);
        }
        public  bool UpdateAllStudentNullSex(string sex)
        {
            return AdministratorService.UpdateAllStudentNullSex(sex);
        }
        public  bool UpdateAllAdminNullType(string type)
        {
            return AdministratorService.UpdateAllAdminNullType(type);
        }
        public  bool ResetTeacherPassword(string Tno, string pwd)
        {
            return AdministratorService.ResetTeacherPassword(Tno,pwd);
        }
        public  bool ResetStudentPassword(string Sno, string pwd)
        {
            return AdministratorService.ResetStudentPassword(Sno, pwd);
        }
        public  bool ResetAdminPassword(string Ano, string pwd)
        {
            return AdministratorService.ResetAdminPassword(Ano, pwd);
        }
    }
}