using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Services
{
    public class StudentCourseAssocService
    {
        #region Properties

        private StudentCourseAssocRepository StudentCourseAssocRepository;

        #endregion

        #region Constructor

        public StudentCourseAssocService()
        {
            // Initialize the repositories
            StudentCourseAssocRepository = new StudentCourseAssocRepository();
        }

        #endregion

        #region Public Methods

        public StudentCourseAssocModel InsertAssoc(StudentCourseAssocModel assocModel)
        {
            var addedAssoc = new StudentCourseAssocModel();

            try
            {
                // Null check the model, then insert the association
                if (assocModel.IdCourse > 0 && assocModel.IdStudent > 0)
                {
                    addedAssoc = StudentCourseAssocRepository.InsertAssoc(assocModel) as StudentCourseAssocModel;
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return addedAssoc;
        }

        public StudentCourseAssocModel GetAssoc(StudentCourseAssocModel assocModel)
        {
            var assoc = new StudentCourseAssocModel();

            try
            {
                // Null check the parameters, then get the association
                if (assocModel.IdCourse > 0 && assocModel.IdStudent > 0)
                {
                    assoc = StudentCourseAssocRepository.GetAssoc(assocModel) as StudentCourseAssocModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return assoc;
        }

        public List<StudentCourseAssocModel> ListAssocs(StudentCourseAssocModel assocModel)
        {
            var assocs = new List<StudentCourseAssocModel>();

            try
            {
                // Get list of all associations
                assocs = StudentCourseAssocRepository.ListAssocs(assocModel).ConvertAll(c => (StudentCourseAssocModel)c);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return assocs;
        }

        public bool DeleteAssoc(StudentCourseAssocModel assocModel)
        {
            var deleted = false;

            try
            {
                // Null check the parameters, then get the association
                if (assocModel.IdCourse > 0 && assocModel.IdStudent > 0)
                {
                    deleted = StudentCourseAssocRepository.DeleteAssoc(assocModel);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return deleted;
        }

        #endregion
    }
}
