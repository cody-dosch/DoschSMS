using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Repositories;
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Services
{
    public class InstructorCourseAssocService
    {
        #region Properties

        private InstructorCourseAssocRepository InstructorCourseAssocRepository;

        #endregion

        #region Constructor

        public InstructorCourseAssocService()
        {
            // Initialize the repositories
            InstructorCourseAssocRepository = new InstructorCourseAssocRepository();
        }

        #endregion

        #region Public Methods

        public InstructorCourseAssocModel InsertAssoc(InstructorCourseAssocModel assocModel)
        {
            var addedAssoc = new InstructorCourseAssocModel();

            try
            {
                // Null check the model, then insert the association
                if (assocModel != null)
                {
                    addedAssoc = InstructorCourseAssocRepository.InsertAssoc(assocModel) as InstructorCourseAssocModel;
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }

            return addedAssoc;
        }

        public InstructorCourseAssocModel UpdateAssoc(InstructorCourseAssocModel assocModel)
        {
            var updatedAssoc = new InstructorCourseAssocModel();

            try
            {
                // Null check the model, then update the association
                if (assocModel != null)
                {
                    updatedAssoc = InstructorCourseAssocRepository.UpdateAssoc(assocModel) as InstructorCourseAssocModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return updatedAssoc;
        }

        public InstructorCourseAssocModel GetAssoc(int courseId)
        {
            var assoc = new InstructorCourseAssocModel();

            try
            {
                // Null check the parameters, then get the association
                if (courseId > 0)
                {
                    assoc = InstructorCourseAssocRepository.GetAssoc(courseId) as InstructorCourseAssocModel;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return assoc;
        }

        public List<InstructorCourseAssocModel> ListAssocs(InstructorCourseAssocModel assocModel)
        {
            var assocs = new List<InstructorCourseAssocModel>();

            try
            {
                // Get list of all associations
                assocs = InstructorCourseAssocRepository.ListAssocs(assocModel).ConvertAll(c => (InstructorCourseAssocModel)c);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return assocs;
        }

        public bool DeleteAssoc(int courseId)
        {
            var deleted = false;

            try
            {
                // Null check the parameters, then get the association
                if (courseId > 0)
                {
                    deleted = InstructorCourseAssocRepository.DeleteAssoc(courseId);
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
