﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {


        public APIHelper(ApplicationManager manager)
            : base(manager)
        {

        }


        public void CreateNewProject(AccountData account, ProjectData projectData)
        {
            mantis.MantisConnectPortTypeClient client = new mantis.MantisConnectPortTypeClient();
            mantis.ProjectData project = new mantis.ProjectData();
            project.name = projectData.Name;
            project.description = projectData.Description;

            client.mc_project_add(account.Name, account.Password, project);

            
        }

        public List<mantis.ProjectData> GetProjectsList(AccountData account)
        {
            mantis.MantisConnectPortTypeClient client = new mantis.MantisConnectPortTypeClient();
            mantis.ProjectData[] projectDatas = client.mc_projects_get_user_accessible(account.Name, account.Password);
            return projectDatas.ToList();
        }
    }
}
